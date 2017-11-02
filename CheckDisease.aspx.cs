using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class CheckDisease : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected int CountDistinct()
    {
        string filepath = Server.MapPath("./Docs");

        filepath += "\\Distinct.txt";
        int count = 0;

        if (File.Exists(filepath))
        {
            StreamReader sr = new StreamReader(filepath);
            while (!sr.EndOfStream)
            {
                string word_prev = sr.ReadLine();

                if (word_prev.ToUpper().Trim() != "")
                    count++;
            }
            sr.Close();
        }

        return count;
    }

    protected int getWordCount(string word, string path)
    {
        StreamReader sr = new StreamReader(path);

        int count = 0;

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            string[] words = line.Split(' ');

            for (int index = 0; index < words.Length; index++)
            {
                if (word.ToUpper() == words[index].ToUpper())
                    count++;
            }
        }
        sr.Close();

        return count;
    }

    protected int getLineCount(string path)
    {
        StreamReader sr = new StreamReader(path);

        int count = 0;

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            count++;
        }
        sr.Close();

        return count;
    }

    protected int getTotalWordCount(string path)
    {
        StreamReader sr = new StreamReader(path);

        int count = 0;

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            string[] words = line.Split(' ');

            for (int index = 0; index < words.Length; index++)
            {
                if (words[index].ToUpper().Trim() != "")
                    count++;
            }
        }
        sr.Close();

        return count;
    }

    protected void MakeDistinct_File(string filepath)
    {
        StreamReader sr = new StreamReader(filepath);

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            string[] words = line.Split(' ');

            for (int index = 0; index < words.Length; index++)
            {
                MakeDistinctWords(words[index]);
            }
        }
        sr.Close();
    }

    protected void MakeDistinctWords(string word)
    {
        string filepath = Server.MapPath("./Docs");

        filepath += "\\Distinct.txt";

        int exist = 0;
        if(File.Exists(filepath))
        {
            StreamReader sr = new StreamReader(filepath);
            while (!sr.EndOfStream)
            {
                string word_prev = sr.ReadLine();

                if (word_prev.ToUpper() == word.ToUpper())
                    exist = 1;
            }
            sr.Close();
        }
        if (exist == 0)
        {
            StreamWriter sw = new StreamWriter(filepath, true);
            sw.WriteLine(word);
            sw.Close();
        }
    }

    protected void MakeNewFile(string filepath, string filepath1)
    {
        string filepath2 = Server.MapPath("./Docs");

        filepath2 += "\\TestFile.txt";

        updFile3.SaveAs(filepath2);

        string html = "<table>";

        StreamReader sr = new StreamReader(filepath2);
        while (!sr.EndOfStream)
        {
            string symp = sr.ReadLine();

            html += "<tr><td>";
            html += symp;
            html += "</td>";

            double line1 = getLineCount(filepath);
            double line2 = getLineCount(filepath1);


            double prob1 = line1 / (line1 + line2);
            double prob2 = line2 / (line1 + line2);

            string[] symps = symp.Split(' ');

            double den = getTotalWordCount(filepath) + CountDistinct();

            for (int index = 0; index < symps.Length; index++)
            {
                if (symps[index].Trim() != "")
                {
                    double num = Convert.ToDouble(getWordCount(symps[index], filepath)) + 1.0;
                    prob1 *= num / den;
                }
            }

            den = getTotalWordCount(filepath1) + CountDistinct();

            for (int index = 0; index < symps.Length; index++)
            {
                if (symps[index].Trim() != "")
                {
                    double num = Convert.ToDouble(getWordCount(symps[index], filepath1)) + 1.0;
                    prob2 *= num / den;
                }
            }

            //lblMessg.Text = "Prob of Disease 1 = " + prob1.ToString() + ", Prob of Disease 2 = " + prob2.ToString() + "<br />";
            if (prob1 > prob2)
                html+= "<td>" + txtDis1.Text + "</td>";
            else
                html += "<td>" + txtDis2.Text + "</td>";

            html += "<td>" + prob1.ToString() + "</td>";
            html += "<td>" + prob2.ToString() + "</td></tr>";
        }

        html += "</table>";
        sr.Close();

        //Response.ContentType = application/vnd.ms-excel;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AppendHeader("Content-Disposition", "attachment; filename=Report_.xls");
        this.EnableViewState = false;
        Response.Write(html);
        Response.End();
    }


    protected void btnCheck_Click(object sender, EventArgs e)
    {
        string filepath = Server.MapPath("./Docs");

        filepath += "\\Dis1.txt";

        updFile.SaveAs(filepath);

        string filepath1 = Server.MapPath("./Docs");

        filepath1 += "\\Dis2.txt";

        updFile2.SaveAs(filepath1);

        string filepath2 = Server.MapPath("./Docs");

        filepath2 += "\\Distinct.txt";

        if (File.Exists(filepath2))
        {
            File.Delete(filepath2);
        }
        MakeDistinct_File(filepath);
        MakeDistinct_File(filepath1);

        string symp = txtSymp.Text;

        double line1 = getLineCount(filepath);
        double line2 = getLineCount(filepath1);


        double prob1=line1/(line1+line2);
        double prob2 = line2 / (line1 + line2);

        string[] symps = symp.Split(' ');

        double den = getTotalWordCount(filepath) + CountDistinct();

        for (int index = 0; index < symps.Length; index++)
        {
            if (symps[index].Trim() != "")
            {
                double num = Convert.ToDouble(getWordCount(symps[index], filepath)) + 1.0;
                prob1 *= num / den;
            }
        }

        den = getTotalWordCount(filepath1) + CountDistinct();

        for (int index = 0; index < symps.Length; index++)
        {
            if (symps[index].Trim() != "")
            {
                double num = Convert.ToDouble(getWordCount(symps[index], filepath1)) + 1.0;
                prob2 *= num / den;
            }
        }

        lblMessg.Text = "Prob of Disease 1 = " + prob1.ToString() + ", Prob of Disease 2 = " + prob2.ToString() + "<br />";
        if (prob1 > prob2)
            lblMessg.Text += "Hence Disease appears to be : " + txtDis1.Text;
        else
            lblMessg.Text += "Hence Disease appears to be : " + txtDis2.Text;

    }
    protected void btnSympFile_Click(object sender, EventArgs e)
    {
        string filepath = Server.MapPath("./Docs");

        filepath += "\\Dis1.txt";

        updFile.SaveAs(filepath);

        string filepath1 = Server.MapPath("./Docs");

        filepath1 += "\\Dis2.txt";

        updFile2.SaveAs(filepath1);

        string filepath2 = Server.MapPath("./Docs");

        filepath2 += "\\Distinct.txt";

        if (File.Exists(filepath2))
        {
            File.Delete(filepath2);
        }
        MakeDistinct_File(filepath);
        MakeDistinct_File(filepath1);
        MakeNewFile(filepath, filepath1);
    }
}