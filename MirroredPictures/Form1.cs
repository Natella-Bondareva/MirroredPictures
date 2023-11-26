using System.Text.RegularExpressions;

namespace MirroredPictures
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Regex regexExtForImage = new Regex("^((.bmp)|(.gif)|(.tiff?)|(.jpe?g)|(.png))$", RegexOptions.IgnoreCase);
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (var file in files)
            {
                if (regexExtForImage.IsMatch(Path.GetExtension(file)))
                {
                    comboBox1.Items.Add(file);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imagePath = comboBox1.SelectedItem.ToString();
            try
            {
                Image selectedImage = Image.FromFile(imagePath);
                pictureBox1.Image = selectedImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження зображення: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imagePath = comboBox1.SelectedItem.ToString();
            string name = "-mirrored.gif";
            Bitmap image = new Bitmap(imagePath);
            string newName = Path.ChangeExtension(imagePath, null);
            newName += name;
            image.RotateFlip(RotateFlipType.Rotate180FlipY);
            image.Save(newName);
            pictureBox2.Image = Image.FromFile(newName);

        }
    }
}