using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for Config
/// </summary>
/// 

public struct ImageSettings
{
    public string image_column;
    public string image_folder;
    public string image_500x500_folder;
    public string image_250x350_folder;
    public string image_120x130_folder;
    public string image_120x128_folder;
    public string image_70x75_folder;

    public string image_folder_path;
    public string image_500x500_folder_path;
    public string image_250x350_folder_path;
    public string image_120x130_folder_path;
    public string image_120x128_folder_path;
    public string image_70x75_folder_path;
}

public struct ImageDetailSettings
{
    public string image_detail_column;
    public string image_detail_folder;

    public string image_detail_folder_path;
}

public struct PDFSettings
{
    public string pdf_column;
    public string pdf_folder;

    public string pdf_folder_path;
}

public class Config
{
    public Config()
    {

    }

    public ImageSettings imageDetails(string imgFolder)
    {
        ImageSettings imageDetail = new ImageSettings();
        if (imgFolder == "1")
        {
            imageDetail.image_column = "imageUrl";
            imageDetail.image_folder = "~/pages/big/";
            imageDetail.image_500x500_folder = "~/pages/W500H550_1/";
            imageDetail.image_250x350_folder = "~/pages/W250H350_1/";
            imageDetail.image_120x130_folder = "~/pages/W120H130_1/";
            imageDetail.image_120x128_folder = "~/pages/W120H128_1/";
            imageDetail.image_70x75_folder = "~/pages/W70H75_1/";
        }
        else
        {
            imageDetail.image_column = "imageUrl" + imgFolder;
            imageDetail.image_folder = "~/pages/big" + imgFolder + "/";
            imageDetail.image_500x500_folder = "~/pages/W500H550_" + imgFolder + "/";
            imageDetail.image_250x350_folder = "~/pages/W250H350_" + imgFolder + "/";
            imageDetail.image_120x130_folder = "~/pages/W120H130_" + imgFolder + "/";
            imageDetail.image_120x128_folder = "~/pages/W120H128_" + imgFolder + "/";
            imageDetail.image_70x75_folder = "~/pages/W70H75_" + imgFolder + "/";
        }

        imageDetail.image_folder_path = imageDetail.image_folder;
        imageDetail.image_500x500_folder_path = imageDetail.image_500x500_folder;
        imageDetail.image_250x350_folder_path = imageDetail.image_250x350_folder;
        imageDetail.image_120x130_folder_path = imageDetail.image_120x130_folder;
        imageDetail.image_120x128_folder_path = imageDetail.image_120x128_folder;
        imageDetail.image_70x75_folder_path = imageDetail.image_70x75_folder;
        imageDetail.image_folder_path = imageDetail.image_folder_path.Replace("~/pages/", "").Replace("/", "\\");
        imageDetail.image_500x500_folder_path = imageDetail.image_500x500_folder_path.Replace("~/pages/", "").Replace("/", "\\");
        imageDetail.image_250x350_folder_path = imageDetail.image_250x350_folder_path.Replace("~/pages/", "").Replace("/", "\\");
        imageDetail.image_120x130_folder_path = imageDetail.image_120x130_folder_path.Replace("~/pages/", "").Replace("/", "\\");
        imageDetail.image_120x128_folder_path = imageDetail.image_120x128_folder_path.Replace("~/pages/", "").Replace("/", "\\");
        imageDetail.image_70x75_folder_path = imageDetail.image_70x75_folder_path.Replace("~/pages/", "").Replace("/", "\\");

        return imageDetail;
    }

    public PDFSettings pdfDetails(string imgFolder)
    {
        PDFSettings pdfDetail = new PDFSettings();
        if (imgFolder == "1")
        {
            pdfDetail.pdf_column = "fileName";
            pdfDetail.pdf_folder = "~/PDFS/";
        }
        else if (imgFolder == "2")
        {
            pdfDetail.pdf_column = "specPDF";
            pdfDetail.pdf_folder = "~/PDF_INSTRUCTION/";
        }
        else
        {
            pdfDetail.pdf_column = "fileName";
            pdfDetail.pdf_folder = "~/PDFS/";
        }

        pdfDetail.pdf_folder_path = pdfDetail.pdf_folder;
        pdfDetail.pdf_folder_path = pdfDetail.pdf_folder_path.Replace("~", "").Replace("/", "\\");

        return pdfDetail;
    }

    public ImageDetailSettings imageDetailDetails(string imgFolder)
    {
        ImageDetailSettings imageDetailDetail = new ImageDetailSettings();
        if (imgFolder == "1")
        {
            imageDetailDetail.image_detail_column = "detailImage";
            imageDetailDetail.image_detail_folder = "~/pages/detailImage/";
        }
        else
        {
            imageDetailDetail.image_detail_column = "detailImage" + imgFolder;
            imageDetailDetail.image_detail_folder = "~/pages/detailImage" + imgFolder + "/";
        }

        imageDetailDetail.image_detail_folder_path = imageDetailDetail.image_detail_folder;
        imageDetailDetail.image_detail_folder_path = imageDetailDetail.image_detail_folder_path.Replace("~/pages/", "").Replace("/", "\\");

        return imageDetailDetail;
    }

}


