using System.Linq.Expressions;
using UnityEngine;
using LootLocker.Requests;
using System.IO;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

public class Leaderboard : MonoBehaviour
{
    public int ID;
    public bool upload = false;
    public bool isInternetAvailable = false;


    public LootLockerLeaderboardMember[] members;
    public delegate void OnLeaderboardUpdate(LootLockerLeaderboardMember[] members);
    public static event OnLeaderboardUpdate onLeaderboardUpdate;

    public static Leaderboard _instance = null;

    public const int Max_VALUE = 100;


    private void Awake()
    {
        isInternetAvailable = InternetConnectivity.isInternetAvailable;
        _instance = this;
    }
    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Session started");
                //isInternetAvailable = true;
            }
            else
            {
                Debug.Log("Session failed");
                //isInternetAvailable = false;
            }
        });
    }

    void OnEnable()
    {
        ScoreManagement.scoreUpdated += SubmitScore;
    }

    void OnDisable()
    {
        ScoreManagement.scoreUpdated -= SubmitScore;
    }

    /// <summary>
    /// This is called when the score is updated.
    /// </summary>
    /// <param name="_currectScore"></param>
    public void SubmitScore(int _currectScore)
    {
        if (!InternetConnectivity.isInternetAvailable) return;
        LootLockerSDKManager.SubmitScore(GameData._instance.userDetails.userName, _currectScore, ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Score submitted");
            }
            else
            {
                Debug.Log("Score failed");
            }
        });
    }

    /// <summary>
    /// This is called to get all the scores
    /// </summary>
    [System.Obsolete]
    public void FetchLeaderboardData()
    {
        if (!InternetConnectivity.isInternetAvailable) return;

        LootLockerSDKManager.GetScoreListMain(ID, 100, 0, (response) =>
        {
            if (response.success)
            {
                members = response.items;
                if (onLeaderboardUpdate != null)
                {
                    onLeaderboardUpdate(members);
                }
            }
        });
    }


    //==================================================================================================================
    //
    //                                           EXPORT TO CSV
    //
    //==================================================================================================================
    /// <summary>
    /// Export to CSV
    /// </summary>
    public void ExportToCsv()
    {
        for (var i = 0; i < members.Length; i++)
        {
            CSVManager.AppendToReport(
                new string[4] {
                "#" + members[i].rank,
                members[i].member_id,
                members[i].score.ToString(),
                SetRankMessage(members[i].rank),
                }
            );
        }

        OpenFile();
    }

    public string SetRankMessage(int rank)
    {
        string finalMessage = "";
        if (rank.Equals(1) || rank.Equals(2) || rank.Equals(3)) finalMessage = "Congratulation!! You are ranked #" + rank.ToString();
        else finalMessage = "Need to work hard to be on Rank #1 from #" + rank.ToString();
        return finalMessage;
    }


    //==================================================================================================================
    //
    //                                           EXPORT TO PDF
    //
    //==================================================================================================================
    /// <summary>
    /// Export to PDF
    /// </summary>

    public bool start = false;
    private void OnValidate()
    {
        if (start)
        {
            start = false;
            CreatePdf();
            Application.OpenURL(Application.streamingAssetsPath + "/" + "Sample.pdf");
        }
    }
    public void CreatePdf()
    {

        //Create a new PDF document.

        PdfDocument document = new PdfDocument();

        //Add a page to the document.

        PdfPage page = document.Pages.Add();

        //Create PDF graphics for the page.

        PdfGraphics graphics = page.Graphics;

        //Set the standard font.

        PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

        //Draw the text.

        graphics.DrawString("Rank", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));
        graphics.DrawString("Name", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(Max_VALUE, 0));
        graphics.DrawString("Score", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(2 * Max_VALUE, 0));
        graphics.DrawString("Message", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(3 * Max_VALUE, 0));



        // for (var i = 0; i < members.Length; i++)
        // {
        //     graphics.DrawString(members[i].rank.ToString(), font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, Max_VALUE / 4));
        //     graphics.DrawString(members[i].member_id, font, PdfBrushes.Black, new Syncfusion.Drawing.PointF((i + 1) * Max_VALUE, (i + 1) * Max_VALUE / 4));
        //     graphics.DrawString(members[i].score.ToString(), font, PdfBrushes.Black, new Syncfusion.Drawing.PointF((i + 1) * 2 * Max_VALUE, (i + 1) * Max_VALUE / 4));
        //     graphics.DrawString("Welcome to my board", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF((i + 1) * 3 * Max_VALUE, (i + 1) * Max_VALUE / 4));
        //}



        //Create the stream object.

        MemoryStream stream = new MemoryStream();

        //Save the document into memory stream.

        document.Save(stream);

        //If the position is not set to '0' then the PDF will be empty.

        //  stream.Position = 0;

        //Close the document.

        File.WriteAllBytes("Sample.pdf", stream.ToArray());

        System.Diagnostics.Process.Start("Sample.pdf", Application.streamingAssetsPath);

    }

    private void OpenFile()
    {
        Application.OpenURL(CSVManager.GetFilePath());
    }
}