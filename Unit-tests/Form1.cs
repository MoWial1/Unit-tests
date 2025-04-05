using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Unit_tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            string inputText = txtInput.Text;
            string specialCharsInput = txtSpecialChars.Text;

            if (string.IsNullOrWhiteSpace(specialCharsInput))
            {
                MessageBox.Show("Please enter at least one special character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var specialCharacters = new HashSet<char>(specialCharsInput);
            var analyzer = new TextAnalyzer();

            int specialCharCount = analyzer.CountSpecialCharacters(inputText, specialCharacters);
            lblResult.Text = $"Number of special characters: {specialCharCount}";
        }
        public class TextAnalyzer
        {
            public int CountSpecialCharacters(string input, HashSet<char> specialCharacters)
            {
                if (input == null)
                    throw new ArgumentNullException(nameof(input));
                if (specialCharacters == null)
                    throw new ArgumentNullException(nameof(specialCharacters));

                int count = 0;
                foreach (char c in input)
                {
                    if (specialCharacters.Contains(c))
                    {
                        count++;
                    }
                }
                return count;
            }
        }
    }
}
