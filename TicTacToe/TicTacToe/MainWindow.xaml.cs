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

        /// <summary>
        /// Starts a new game and clears all values back to the start
        /// </summary>
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

        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">The events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e) {
            //Start a new game on the click after it finished
            if (mGameEnded) {
                NewGame();
                return;
            }

            // Cast the sender to a button
            var button = (Button)sender;

            //Find the buttons position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            // Don't do anything if it already has a value in it
            if (mResults[index] != MarkType.Free)
                return;

            // Set the cell value based on which player turn is it
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            // Set button text to the result
            button.Content = mPlayer1Turn ? "X" : "O";

            // Change nought to green
            if (!mPlayer1Turn)
                button.Foreground = Brushes.Red;

            // Toggle the player's turns
            mPlayer1Turn ^= true;

            // Check for a winner
            CheckForAWinner();
        }

        /// <summary>
        /// Checks if there is a winner of a 3 line straight
        /// </summary>
        private void CheckForAWinner() {
            CheckForHorizontalWins();
            CheckForVerticalWins();
            CheckForCrossWins();

            if (!mGameEnded) {
                // Check for no winner and full board
                if (!mResults.Any(result => result == MarkType.Free)) {
                    // Game ends
                    mGameEnded = true;

                    // Turn every cell orange
                    Container.Children.Cast<Button>().ToList().ForEach(button => {
                        // Change background, foreground and content to default values
                        button.Background = Brushes.Orange;
                    });
                }
            }
        }

        private void CheckForCrossWins() {
            //
            // - Cross 1
            //
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0]) {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in grey
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Gray;
            }
            //
            // - Cross 2
            //
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2]) {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in grey
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Gray;
            }
        }

        private void CheckForVerticalWins() {
            // Check for vertical wins
            //
            // - Column 0
            //
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0]) {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in grey
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Gray;
            }
            //
            // - Column 1
            //
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1]) {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in grey
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Gray;
            }
            //
            // - Column 2
            //
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2]) {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in grey
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Gray;
            }
        }

        private void CheckForHorizontalWins() {
            // Check for horizontal wins
            //
            // - Row 0
            //
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0]) {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in grey
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Gray;
            }
            //
            // - Row 1
            //
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3]) {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in grey
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Gray;
            }
            //
            // - Row 2
            //
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6]) {
                // Game ends
                mGameEnded = true;

                // Highlight winning cells in grey
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Gray;
            }
        }
    }
}
