
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

ApplicationConfiguration.Initialize();
Application.Run(new JokeForm());

public class JokeForm : Form
{
    private Label jokeLabel;
    private Label jokeButton;
    private Random random = new Random();

    private List<string> jokes = new List<string>
    {
        "Why don't eggs tell jokes?\n\nThey'd crack each other up.",

        "What kind of music do balloons hate?\n\nPop.",

        "Why was the math book sad?\n\nIt had too many problems.",

        "What do you call a fish wearing a bowtie?\n\nSofishticated.",

        "Why did the golfer bring two pairs of pants?\n\nIn case he got a hole in one.",

        "What do you call cheese that isn't yours?\n\nNacho cheese.",

        "Why can't your nose be 12 inches long?\n\nBecause then it would be a foot.",

        "What do you call a bear with no teeth?\n\nA gummy bear.",

        "Why did the cookie go to the doctor?\n\nBecause he felt crummy.",

        "How do you organize a space party?\n\nYou planet.",

        "What do you call an alligator in a vest?\n\nAn investigator.",

        "Why did the coffee file a police report?\n\nIt got mugged.",

        "What do you call a cow with no legs?\n\nGround beef.",

        "Why don't scientists trust atoms?\n\nBecause they make up everything.",

        "What do you call a factory that makes okay products?\n\nA satisfactory.",

       "Why did the pastor bring a ladder to church?\n\nHe wanted to reach the higher calling.",

        "Why did the Bible student carry a pencil?\n\nTo draw nearer to God.",

        "What is a Christian comedian's favorite exercise?\n\nCross training.",

        "Why don't church mice ever get lost?\n\nThey follow the pew prints.",

        "What did one disciple say to the other at dinner?\n\nPassover the bread." ,

        "Why did the coffee file a police report?\n\nIt got mugged.",

        "What do you call a cow with no legs?\n\nGround beef.",

        "What do you call a mouse that says bad words?\n\nCursor.",

        "Why should you not throw false teeth at a car?\n\nYou might dentur car",

       "What do you call a group of Trans Female Superheroes?\n\nEx-Men.",

        "What is another name for an Asian Hitman?\n\nChinese Takeout.",

        "What is the opposite of Isolate?\n\nYou so early.",

        "A Dyslexic Man walks into a Bra.",

        "I threw a boomerang a few years ago.\n\nNow i live in constant fear."

    };

    public JokeForm()
    {
        Text = "Marcus' Comedy Club Joke Machine";
        Width = 1220;
        Height = 920;
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        try
        {
            string imagePath = Path.Combine(AppContext.BaseDirectory, "comedyclub_background.png");

            if (File.Exists(imagePath))
            {
                BackgroundImage = Image.FromFile(imagePath);
                BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                MessageBox.Show("Could not find background image:\n\n" + imagePath);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading background image:\n\n" + ex.Message);
        }

        jokeLabel = new Label();
        jokeLabel.Text = "Click the button below and let the comedy begin!";
        jokeLabel.Font = new Font("Georgia", 12, FontStyle.Bold);
        jokeLabel.ForeColor = Color.Black;
        jokeLabel.BackColor = Color.Transparent;
        jokeLabel.TextAlign = ContentAlignment.MiddleCenter;
        jokeLabel.Width = 570;
        jokeLabel.Height = 185;
        jokeLabel.Top = 550;
        jokeLabel.Padding = new Padding(20);

        jokeButton = new Label();
        jokeButton.Text = "TELL ME A JOKE!";
        jokeButton.Font = new Font("Arial Black", 14, FontStyle.Bold);
        jokeButton.ForeColor = Color.Black;
        jokeButton.BackColor = Color.Transparent;
        jokeButton.TextAlign = ContentAlignment.MiddleCenter;
        jokeButton.Width = 380;
        jokeButton.Height = 65;
        jokeButton.Top = 750;
        jokeButton.Cursor = Cursors.Hand;
        jokeButton.Click += JokeButton_Click;

        Controls.Add(jokeLabel);
        Controls.Add(jokeButton);

        CenterControls();

        jokeLabel.BringToFront();
        jokeButton.BringToFront();

        Load += (s, e) => CenterControls();
        Resize += (s, e) => CenterControls();
    }

    private void CenterControls()
    {
        jokeLabel.Left = (ClientSize.Width - jokeLabel.Width) / 2;
        jokeButton.Left = (ClientSize.Width - jokeButton.Width) / 2;
    }

    private void JokeButton_Click(object? sender, EventArgs e)
    {
        int index = random.Next(jokes.Count);
        jokeLabel.Text = jokes[index];
    }
}