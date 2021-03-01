using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AuthorizationDenied="Yetkiniz yok.";
        public static string ThereAreNoCarsRegisteredInTheSystem = "Sistemde kayıtlı araba yok";

        public static string CarNotFound = "Araba bulunamadı";
        public static string CheckTheModelYearOfTheCar = "Arabanın model yılını kontrol edin";
        public static string CarAdded = "Araba Eklendi";
        public static string CarIdIsWrong = "Araba kimliği yanlış";
        public static string CarUpdated = "Araba Güncellendi";
        public static string CarDeleted = "Araba Silindi";

        public static string NoBrandsRegisteredInTheSystem = "Sistemde Kayıtlı Marka Yok";
        public static string BrandNotFound = "Marka bulunamadı";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandIdIsWrong = "Marka kimliği yanlış";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandNameMustContainAtLeastThreeCharacters= "Marka Adı en az üç Karakter içermelidir";

        public static string PhotosOfTheCarNotFound = "Arabanın fotoğrafları bulunamadı";
        public static string CarPhotosNotFound= "Araba fotoğrafları bulunamadı";
        public static string CarImageAdded = "Arabaya fotoğraf eklendi";
        public static string CarImageIdIsWrong = "fotoğraf kimliği yanlış";
        public static string CarImageUpdated = "Arabanın fotoğrafı Güncellendi";
        public static string CarImageNotFound = "Fotoğraf bulunamadı ";
        public static string CarImageDeleted = "Arabanın fotoğrafı Silindi";
    }
}
