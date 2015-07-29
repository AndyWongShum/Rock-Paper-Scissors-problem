using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace WebApplicationRockPaperScissor
{
    public partial class MainRPS : System.Web.UI.Page
    {
        RockScissorPaperLogic go = new RockScissorPaperLogic();
        string result;
       
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            go.setFormat(TextBox1.Text);
            result = go.match();
            if (result == "error")
            {
                TextBox2.Text = "";
                Page.ClientScript.RegisterStartupScript(
                   Page.GetType(),
                   "MessageBox",
                   "<script language='javascript'>alert('" + "Please check your strategy or the number of players" + "');</script>");
            }
            else {
                
                TextBox2.Text = "";
                TextBox2.Text = result;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Boolean fileOK = false;
            String path = Server.MapPath("~/UploadedTournaments/");
            if (FileUpload1.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] allowedExtensions =
                    {".txt"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    FileUpload1.PostedFile.SaveAs(path
                        + FileUpload1.FileName);
                    FileManager f = new FileManager();
                   TextBox1.Text = f.readFile(path+ FileUpload1.FileName);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "File uploaded" + "');</script>");
               }
               catch (Exception ex)
               {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "File could not be uploaded" + "');</script>");
               }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + "Cannot accept files of this type." + "');</script>");
            }

        }
    }
}