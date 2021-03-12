using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FilesHelper
{
    public class FileHelper : IFileHelper
    {
        public IDataResult<string> Upload(IFormFile file, string path,string fileType)
        {
            var resultFileRotates = FileExtensionRotates(fileType);
            if (resultFileRotates.Success)
            {
                var resultFileControl = FileControl(file, resultFileRotates.Data);
                if (resultFileControl.Success)
                {
                    string replaceFileName = resultFileControl.Data;
                    var files = Path.Combine(path + replaceFileName);
                    using (var fileStream = new FileStream(files, FileMode.Create))
                    {
                        file.CopyToAsync(fileStream);
                    }
                    return new SuccessDataResult<string>(replaceFileName);
                }
                return new ErrorDataResult<string>(resultFileControl.Message);
            }
            return  new ErrorDataResult<string>(resultFileRotates.Message);
            
        }

        public IResult Delete(string path)
        {
            throw new NotImplementedException();
        }

        public IResult Move(string oldPath, string newPath)
        {
            throw new NotImplementedException();
        }


        public IDataResult<string[]> FileExtensionRotates(string FileType)
        {
            if (FileType.ToUpper()=="IMAGE")
            {
                string[] extensions = { "Images",".jpg", ".tif",".png", ".jpeg", ".bmp" };
                return new SuccessDataResult<string[]>(extensions) ;
            }
            return new ErrorDataResult<string[]>();
        }

        public IDataResult<string> FileControl(IFormFile file, string[] fileExtentions)
        {
            var getFileExtensions = Path.GetExtension(file.FileName).ToLower();
            for (int i = 1; i < fileExtentions.Length; i++)
            {
                if (fileExtentions[i].ToLower() == getFileExtensions)
                {
                    string fileName = "\\" + fileExtentions[0] + "\\" + Guid.NewGuid().ToString() + getFileExtensions;
                    return new SuccessDataResult<string>(fileName);
                }
            }
            return new ErrorDataResult<string>("Gönderilen dosya türü hatalı !");
        }
    }
}
