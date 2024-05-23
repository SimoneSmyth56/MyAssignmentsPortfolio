using ZooManagementSystem.Animals;

namespace ZooManagementSystem
{
    public partial class Form1 : Form
    {
        // Instantiating instances of different animal types
        Lion myLion = new("Lion", "Simba", 10, "Male", 120, "Brown", AnimalType.Mammal);
        Elephant myElephant = new Elephant("Elephant", "Ellie", 15, "Female", 2500, "2m", AnimalType.Mammal);
        Baboon myBaboon = new Baboon("Baboon", "Rafiki", 7, "Male", 40, "40cm", AnimalType.Primate);
        Snake mySnake = new Snake("Snake", "Slytherin", 3, "Female", 5, "1.5m", AnimalType.Reptile);

        // List to store all animals
        private List<ZooAnimals> animalList = new List<ZooAnimals>();

        // Gender constants and array for comboBox data source
        private const string male = "Male";
        private const string female = "Female";
        string[] gender = { male, female };

        // Animal species constants and array for comboBox data source
        private const string LionSpecies = "Lion";
        private const string ElephantSpecies = "Elephant";
        private const string BaboonSpecies = "Baboon";
        private const string SnakeSpecies = "Snake";
        string[] animalSpeciesList = { LionSpecies, ElephantSpecies, BaboonSpecies, SnakeSpecies };

        public Form1()
        {
            InitializeComponent();

            // Adding animals to the list
            animalList.Add(myLion);
            animalList.Add(myElephant);
            animalList.Add(myBaboon);
            animalList.Add(mySnake);

            // Setting data sources for comboBoxes
            comboBox2.DataSource = Enum.GetValues(typeof(AnimalType));
            comboBox1.DataSource = Enum.GetValues(typeof(FoodType));
            comboBox3.DataSource = gender;
            comboBox4.DataSource = animalSpeciesList;
        }

        // Event handler to switch to the second tab
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        // Event handler to display lion information
        private void lionToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            string lionInfo;
            myLion.ViewLionInformation(out lionInfo);
            textBox3.Text = lionInfo;
        }

        // Event handler to display elephant information
        private void elephantToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            string elephantInfo;
            myElephant.ViewElephantInformation(out elephantInfo);
            textBox3.Text = elephantInfo;
        }

        // Event handler to display baboon information
        private void baboonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string baboonInfo;
            myBaboon.ViewBaboonInformation(out baboonInfo);
            textBox3.Text = baboonInfo;
        }

        // Event handler to display snake information
        private void snakeToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            string snakeInfo;
            mySnake.ViewSnakeInformation(out snakeInfo);
            textBox3.Text = snakeInfo;
        }

        // Event handler to switch to the third tab to view animal location
        private void viewAnimalLocationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        // Event handler to display lion location
        private void lionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = myLion.Location(1);
        }

        // Event handler to display elephant location
        private void elephantToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            textBox7.Text = myElephant.Location(2);
        }

        // Event handler to display baboon location
        private void baboonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = myBaboon.Location(3);
        }

        // Event handler to display snake location
        private void snakeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            textBox7.Text = mySnake.Location(4);
        }

        // Event handler to switch to the fourth tab
        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        // Event handler to feed selected animal with selected food
        private void button1_Click_1(object sender, EventArgs e)
        {
            var selectedFood = comboBox1.SelectedItem?.ToString(); // Prevents NullReferenceException if nothing is selected

            // Check which animal is displayed in textBox3 and feed accordingly
            if (textBox3.Text.Contains(myLion.Name) && selectedFood == "Meat")
            {
                MessageBox.Show($"You have fed the lion {selectedFood}");
            }
            else if (textBox3.Text.Contains(myElephant.Name) && (selectedFood == "Leaves" || selectedFood == "Roots" || selectedFood == "Fruit"))
            {
                MessageBox.Show($"You have fed the elephant {selectedFood}");
            }
            else if (textBox3.Text.Contains(myBaboon.Name) && (selectedFood == "Roots" || selectedFood == "Fruit"))
            {
                MessageBox.Show($"You have fed the baboon {selectedFood}");
            }
            else if (textBox3.Text.Contains(mySnake.Name) && selectedFood == "Mice")
            {
                MessageBox.Show($"You have fed the snake some {selectedFood}");
            }
            else
            {
                MessageBox.Show("Oops, this animal doesn't eat that type of food. Please click the Diet Information to see what this animal likes to eat");
            }
        }

        // Event handler to display the sound of the selected animal
        private void button7_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text.Contains(myLion.Name))
            {
                MessageBox.Show(myLion.animalSound);
            }
            if (textBox3.Text.Contains(myElephant.Name))
            {
                MessageBox.Show(myElephant.animalSound);
            }
            if (textBox3.Text.Contains(myBaboon.Name))
            {
                MessageBox.Show(myBaboon.animalSound);
            }
            if (textBox3.Text.Contains(mySnake.Name))
            {
                MessageBox.Show(mySnake.animalSound);
            }
        }

        // Event handler to display diet information of the selected animal
        private void button6_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text.Contains(myLion.Name))
            {
                MessageBox.Show(myLion.LionDietInfo());
            }
            if (textBox3.Text.Contains(myElephant.Name))
            {
                MessageBox.Show(myElephant.ElephantDietInfo());
            }
            if (textBox3.Text.Contains(myBaboon.Name))
            {
                MessageBox.Show(myBaboon.BaboonDietInfo());
            }
            if (textBox3.Text.Contains(mySnake.Name))
            {
                MessageBox.Show(mySnake.SnakeDietInfo());
            }
        }

        // Event handler to add a new animal based on form inputs
        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                AnimalType animalType = (AnimalType)comboBox2.SelectedItem;
                string name = nameTextBox.Text;
                int age = Convert.ToInt32(ageTextBox.Text);
                string gender = (string)comboBox3.SelectedItem;
                double weight = Convert.ToDouble(weightTextBox.Text);
                string animalSpecies = (string)comboBox4.SelectedItem;

                ZooAnimals newAnimal = new ZooAnimals(animalSpecies, name, age, gender, weight, animalType);

                animalList.Add(newAnimal);

                MessageBox.Show("Animal has been added");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid values. Age & Weight should be numeric values || Name should be text.");
            }
        }

        // Method to display all animals in the list
        private void DisplayAnimalList()
        {
            listBox1.Items.Clear();

            // Add each animal's name to the list box
            foreach (ZooAnimals animal in animalList)
            {
                listBox1.Items.Add($"Species: {animal.AnimalSpecies} | Name: {animal.Name} | Age: {animal.Age} years old | Gender: {animal.Gender} | Weight: {animal.Weight} kg | Type: {animal.animalTypeEnum}");
            }
        }

        // Event handler to switch to the fifth tab and display all animals
        private void viewAllAnimalsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
            DisplayAnimalList();
        }

        // Event handler to display the map of the lion's location
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Contains(myLion.Location(1)))
            {
                MapLion lionMap = new MapLion();
                lionMap.ShowDialog();
            }
            if (textBox7.Text.Contains(myElephant.Location(2)))
            {
                MapElephant elephantMap = new MapElephant();
                elephantMap.ShowDialog();
            }
            if (textBox7.Text.Contains(myBaboon.Location(3)))
            {
                MapBaboon baboonMap = new MapBaboon();
                baboonMap.ShowDialog();
            }
            if (textBox7.Text.Contains(mySnake.Location(4)))
            {
                MapSnake snakeMap = new MapSnake();
                snakeMap.ShowDialog();
            }
        }

        // Event handler to display the type of the selected animal
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Contains(myLion.Name))
            {
                MessageBox.Show(myLion.LionType());
            }
            if (textBox3.Text.Contains(myElephant.Name))
            {
                MessageBox.Show(myElephant.ElephantType());
            }
            if (textBox3.Text.Contains(myBaboon.Name))
            {
                MessageBox.Show(myBaboon.BaboonType());
            }
            if (textBox3.Text.Contains(mySnake.Name))
            {
                MessageBox.Show(mySnake.SnakeType());
            }
        }

        // Event handler to display the habitat of the selected animal
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox7.Text.Contains(myLion.Location(1)))
            {
                MessageBox.Show(myLion.LionHabitat());
            }
            if (textBox7.Text.Contains(myElephant.Location(2)))
            {
                MessageBox.Show(myElephant.ElephantHabitat());
            }
            if (textBox7.Text.Contains(myBaboon.Location(3)))
            {
                MessageBox.Show(myBaboon.BaboonHabitat());
            }
            if (textBox7.Text.Contains(mySnake.Location(4)))
            {
                MessageBox.Show(mySnake.SnakeHabitat());
            }
        }

        // Event handler to display climbing/swimming/hibernating behavior of the selected animal
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Contains(myLion.Name))
            {
                MessageBox.Show(myLion.Climb());
            }
            if (textBox3.Text.Contains(myElephant.Name))
            {
                MessageBox.Show(myElephant.Swim());
            }
            if (textBox3.Text.Contains(myBaboon.Name))
            {
                MessageBox.Show(myBaboon.Climb());
            }
            if (textBox3.Text.Contains(mySnake.Name))
            {
                MessageBox.Show(mySnake.Hibernate());
            }
        }

        // Event handler to display the movement behavior of the selected animal
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Contains(myLion.Name))
            {
                MessageBox.Show(myLion.animalMove());
            }
            if (textBox3.Text.Contains(myElephant.Name))
            {
                MessageBox.Show(myElephant.animalMove());
            }
            if (textBox3.Text.Contains(myBaboon.Name))
            {
                MessageBox.Show(myBaboon.animalMove());
            }
            if (textBox3.Text.Contains(mySnake.Name))
            {
                MessageBox.Show(mySnake.animalMove());
            }
        }

        // Event handler to display the sleeping behavior of the selected animal
        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Contains(myLion.Name))
            {
                MessageBox.Show(myLion.animalSleep());
            }
            if (textBox3.Text.Contains(myElephant.Name))
            {
                MessageBox.Show(myElephant.animalSleep());
            }
            if (textBox3.Text.Contains(myBaboon.Name))
            {
                MessageBox.Show(myBaboon.animalSleep());
            }
            if (textBox3.Text.Contains(mySnake.Name))
            {
                MessageBox.Show(mySnake.animalSleep());
            }
        }
    }
}
