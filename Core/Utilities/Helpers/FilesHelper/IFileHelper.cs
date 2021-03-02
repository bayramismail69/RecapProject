using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FilesHelper
{
    public interface IFileHelper
    {
        IDataResult<string> Upload(IFormFile file, string path, string fileType);
        IResult Delete(string path);
        IResult Move(string oldPath,string newPath);
        IDataResult<string> FileControl(IFormFile file, string[] fileExtention);
        IDataResult<string[]> FileExtensionRotates(string FileType);
    }
}
