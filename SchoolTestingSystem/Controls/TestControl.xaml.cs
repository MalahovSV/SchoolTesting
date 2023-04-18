using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolTestingSystem.Controls
{
    /// <summary>
    /// Логика взаимодействия для TestControl.xaml
    /// </summary>
    public partial class TestControl : UserControl
    {
        public TestControl()
        {
            InitializeComponent();
        }

        private async void CreateJSON_Click(object sender, RoutedEventArgs e)
        {
            Model.SchoolTesting testing = new Model.SchoolTesting();
            testing.ID = 1;
            testing.Name = "Арифметика";
            testing.Description= "Арифметика для начальных классов. Проверка знаний";

            Model.Question question1 = new Model.Question(1, "1+1", "Сколько будет 1+1?");
            question1.Answers = new List<Model.Answer>();
            question1.Answers.Add(new Model.Answer(1, "2", "2", 10));
            question1.Answers.Add(new Model.Answer(2, "3", "3", 0));
            question1.Answers.Add(new Model.Answer(2, "4", "4", 0));


            Model.Question question = new Model.Question(2, "3+3", "Сколько будет 3+3?");
            question.Answers = new List<Model.Answer>();
            question.Answers.Add(new Model.Answer(1, "2", "2", 10));
            question.Answers.Add(new Model.Answer(2, "3", "3", 0));
            question.Answers.Add(new Model.Answer(2, "4", "4", 0));

            testing.Questions = new List<Model.Question> { question };
            testing.Questions.Add(question1);
            testing.Questions.Add(question);

            using (FileStream fs = new FileStream("testing.json", FileMode.OpenOrCreate))
            {

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    AllowTrailingCommas = true
                };

                await JsonSerializer.SerializeAsync<Model.SchoolTesting>(fs, testing);
                Console.WriteLine("Class TestingSchool has been saved to json-file");

            }
            getTest();



        }



        protected private Model.SchoolTesting? testingFile;

        private async void getTest()
        {
            using (FileStream fs = new FileStream("testing.json", FileMode.OpenOrCreate))
            {
                testingFile = await JsonSerializer.DeserializeAsync<Model.SchoolTesting>(fs);
                stackQuestions.Children.Add(new Label()
                {
                    Content = testingFile.Description.ToString()
                }
                );
                Console.WriteLine("ID: {0} Name: {1} Description: {2}", testingFile.ID, testingFile.Name, testingFile.Description);
                foreach (Model.Question recordQuestion in testingFile.Questions)
                {
                    stackQuestions.Children.Add(new Label()
                    {
                        Content= recordQuestion.Description.ToString(),
                        DataContext = recordQuestion
                    });
                    Console.WriteLine("    ID: {0}, Name: {1}, Description: {2}", recordQuestion.Id, recordQuestion.Name, recordQuestion.Description);
                    foreach (Model.Answer answer in recordQuestion.Answers)
                    {
                        stackQuestions.Children.Add(new RadioButton()
                        {
                            GroupName = recordQuestion.Name,
                            Content = answer.Description.ToString()
                        });
                        
                        Console.WriteLine("            ID: {0}, Name: {1}, Description: {2}, Balls: {3}", answer.Id, answer.Name, answer.Description, answer.Balls);
                    }
                }
                checkAnswers();
            }
        }


        private void checkAnswers()
        {
            foreach(Object collection in stackQuestions.Children)
            {
                if(collection is Label)
                {
                    Label label = (Label)collection;
                    Model.Question question = label.DataContext as Model.Question;

                    if (question != null)
                    {

                    }
                }
            }
        }
    }
}
