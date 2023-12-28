using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private List<Comment> comments;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            comments = CommentGenerator.CreateComments(5);

            int y = 10;
            foreach (Comment comment in comments)
            {
                CreateItem(comment, new Point(20, y));
                y += 200;
            }
        }

        private GroupBox CreateItem(Comment comment, Point point)
        {
            GroupBox groupBox = new GroupBox();
            CustomButton button = new CustomButton(comment.Id);
            Button likesBtn = new Button();
            Label likesLabel = new Label();
            Button dislikesBtn = new Button();
            Label dislikesLabel = new Label();
            Label idLabel = new Label();
            Label textLabel = new Label();
            Panel panel = new Panel();
            bool liked = false;

            groupBox.SuspendLayout();

            groupBox.Controls.Add(button);
            groupBox.Controls.Add(likesBtn);
            groupBox.Controls.Add(likesLabel);
            groupBox.Controls.Add(dislikesBtn);
            groupBox.Controls.Add(dislikesLabel);
            groupBox.Controls.Add(idLabel);
            groupBox.Controls.Add(textLabel);
            groupBox.Controls.Add(panel);
            groupBox.Location = point;
            groupBox.Margin = new Padding(4);
            groupBox.Name = "groupBox";
            groupBox.Padding = new Padding(4);
            groupBox.Size = new Size(800, 200);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;
            groupBox.Text = comment.FullName;

            idLabel.AutoSize = true;
            idLabel.Location = new Point(10, 25);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(30, 21);
            idLabel.TabIndex = 0;
            idLabel.Text = $"User ID: {comment.Id}";

            textLabel.AutoSize = false;
            textLabel.Location = new Point(10, 50);
            textLabel.Name = "textLabel";
            textLabel.Size = new Size(600, 60);
            textLabel.TabIndex = 1;
            textLabel.Text = $"Message: {comment.Message}";
            textLabel.MaximumSize = new Size(600, 60);

            button.Location = new Point(650, 20);
            button.Name = "button1";
            button.Size = new Size(120, 80);
            button.TabIndex = 4;
            button.Text = "Save";
            button.UseVisualStyleBackColor = true;
            button.Click += (object? sender, EventArgs e) => ShowMessageBoxError();

            likesBtn.Location = new Point(400, 140);
            likesBtn.Name = "likesBtn";
            likesBtn.Size = new Size(100, 35);
            likesBtn.TabIndex = 3;
            likesBtn.Text = "Add like";
            likesBtn.Click += (object? sender, EventArgs e) =>
            {
                if (!liked)
                {
                    likesLabel.Text = "Likes: " + (comment.Likes + 1).ToString();
                }
            };

            likesLabel.AutoSize = true;
            likesLabel.Location = new Point(295, 142);
            likesLabel.BorderStyle = BorderStyle.FixedSingle;
            likesLabel.Name = "likesLabel";
            likesLabel.Size = new Size(80, 20);
            likesLabel.TabIndex = 2;
            likesLabel.Text = "Likes: " + comment.Likes.ToString();

            dislikesBtn.Location = new Point(170, 140);
            dislikesBtn.Name = "dislikesBtn";
            dislikesBtn.Size = new Size(100, 35);
            dislikesBtn.TabIndex = 1;
            dislikesBtn.Text = "Add dislike";
            dislikesBtn.Click += (object? sender, EventArgs e) =>
            {
                dislikesLabel.Text = "Dislikes: " + (comment.Dislikes + 1).ToString();
            };

            dislikesLabel.AutoSize = true;
            dislikesLabel.Location = new Point(45, 142);
            dislikesLabel.BorderStyle = BorderStyle.FixedSingle;
            dislikesLabel.Margin = new Padding(4, 0, 4, 0);
            dislikesLabel.Name = "dislikesLabel";
            dislikesLabel.Size = new Size(80, 20);
            dislikesLabel.TabIndex = 0;
            dislikesLabel.Text = "Dislikes: " + comment.Dislikes.ToString();

            panel.Location = new Point(0, 130);
            panel.Size = new Size(800, 2);
            panel.BackColor = Color.Black;

            this.Controls.Add(groupBox);

            return groupBox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.RemoveByKey("groupBox");

            int y = 10;
            foreach (Comment comment in comments)
            {
                CreateItem(comment, new Point(20, y));
                y += 200;
            }
        }

        private void ShowMessageBoxError()
        {
            ShowErrorMessageBox("Сталася помилка!");
        }

        private void ShowErrorMessageBox(string errorMessage)
        {
            for (int i = 0; i < 100; i++)
            {
                MessageBox.Show(errorMessage, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class CustomButton : Button
    {
        public int ProductId { get; }

        public CustomButton(int productId) : base()
        {
            ProductId = productId;
        }
    }



    public class User
    {
        public int Id { get; }
        public string Name { get; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }


}
