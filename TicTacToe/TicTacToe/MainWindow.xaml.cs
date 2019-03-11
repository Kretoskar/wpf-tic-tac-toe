using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe {
    public partial class MainWindow : Window {

        #region Private Members
            
        /// <summary>
        /// Holds the current results of cells in the active game
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// True if it's player's one turn (X)
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool mGameEnded;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>

        public MainWindow() {
            InitializeComponent();

            NewGame();
        }

        #endregion


        private void NewGame() {
            // Create a new blank array of free cells
            mResults = new MarkType[9];

            for(var i = 0; i < mResults.Length; i++) {
                mResults[i] = MarkType.Free;
            }

            // Make sure player 1 starts the game
            mPlayer1Turn = true;

            // Iterate every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button => {
                // Change background, foreground and content to default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            // Make sure the game hasn't finished
            mGameEnded = false;
        }
    }
}
