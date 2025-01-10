using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WindowsFormsApp2.Form3;
using Formatting = Newtonsoft.Json.Formatting;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                var json = await client.GetStringAsync("https://www.fruityvice.com/api/fruit/all");
                textBox1.Text = json;
                //// Deserialize JSON response to a list of Fruit objects
                //var fruits = JsonConvert.DeserializeObject<List<Fruit>>(json);

                //// Print the name of each fruit to the console
                //foreach (var fruit in fruits)
                //{
                //    listBox1.Items.Add(fruit.Name);
                //}
                var fruits = JsonConvert.DeserializeObject<List<Fruit>>(json);

                // Print the name of each fruit to the console
                foreach (var fruit in fruits)
                {
                    listBox1.Items.Add(" name: "+ fruit.Name+", famlily: "+ fruit.family);
                }


                }
        }

        public class Fruit
        {
            public string Name { get; set; }
            public string family { get; set; }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
