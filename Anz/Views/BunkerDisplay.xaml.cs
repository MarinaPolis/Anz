using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Anz.Models;
using Anz.ViewModel;

namespace Anz.Views
{
    /// <summary>
    /// Interaction logic for BunkerDisplay.xaml
    /// </summary>
    public partial class BunkerDisplay : Window
    {
        private ObservableCollection<CharacterViewModel> characters;

        // Лічильник створених персонажів
        private int characterCount = 0;

        public BunkerDisplay()
        {
            InitializeComponent();
        }
        private void btnGenerateCard_Click(object sender, RoutedEventArgs e)
        {
            //List<CharacterViewModel> characters = new List<CharacterViewModel>();
            if (DataContext is BunkerDisplayModel model)
            {
                int numOfPlayers = model.NumOfPlayers;

                if (characterCount < numOfPlayers)
                {
                    // Створення нового персонажа
                    Character newCharacter = new Character();
                    characterCount++;


                    string character = newCharacter.GenerateCharacter(characterCount);
                    // Відображення створеного персонажа
                    tbCharacterDisplay.Text = character;
                    // Відображення картки
                    imgCard.Visibility = Visibility.Visible;

                    // Створення колекції гравців
                    characters.Add(new CharacterViewModel(character));
                }

                else
                {
                    // Приховує кнопку генерації картки, коли всі персонажі створені
                    btnGenerateCard.Visibility = Visibility.Collapsed;
                    tbCharacterDisplay.Visibility = Visibility.Collapsed;
                    //btnEndTheGame.Visibility = Visibility.Visible;
                    imgCard.Visibility = Visibility.Collapsed;

                    // Показати табличку
                    playerDataGrid.Visibility = Visibility.Visible;

                    // Відображає повідомлення про закінчення гри
                    //tbCharacterDisplay.Text = "Гарної гри! \nНехай врятуються найкмітливіші!";
                    //tbCharacterDisplay.FontSize = 50;
                    //tbCharacterDisplay.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
