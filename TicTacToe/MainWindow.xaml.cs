using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region private members

        private MarkType[] _results;
        private bool _player1Turn;

        private bool _gameEnded;
        //private MarkType[][] _results3;

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        #endregion

        private void NewGame()
        {
            _results = new MarkType[9];

            for (var i = 0; i < 3; ++i)
                _results[i] = MarkType.Free;

            _player1Turn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = String.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            _gameEnded = false;
        }

        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender"> The button that was clicked </param>
        /// <param name="e"> button was clicked </param>
        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (_gameEnded)
            {
                NewGame();
                return;
            }

            var button = (Button) sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            if (_results[index] != MarkType.Free)
                return;

            _results[index] = _player1Turn ? MarkType.Cross : MarkType.Nought;

            if (!_player1Turn)
                button.Foreground = Brushes.Red;

            button.Content = _player1Turn ? 'X' : 'O';

            _player1Turn = !_player1Turn;
            CheckForWinner();
        }

        private void CheckForWinner()
        {
            #region checking rows

            if (_results[0] != MarkType.Free && (_results[0] & _results[1] & _results[2]) == _results[0])
            {
                _gameEnded = true;
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
                return;
            }

            if (_results[3] != MarkType.Free && (_results[3] & _results[4] & _results[5]) == _results[3])
            {
                _gameEnded = true;
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
                return;
            }

            if (_results[6] != MarkType.Free && (_results[6] & _results[7] & _results[8]) == _results[6])
            {
                _gameEnded = true;
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
                return;
            }

            #endregion

            #region checking cols

            if (_results[0] != MarkType.Free && (_results[0] & _results[3] & _results[6]) == _results[0])
            {
                _gameEnded = true;
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
                return;
            }

            if (_results[1] != MarkType.Free && (_results[1] & _results[4] & _results[7]) == _results[1])
            {
                _gameEnded = true;
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
                return;
            }

            if (_results[2] != MarkType.Free && (_results[2] & _results[5] & _results[8]) == _results[2])
            {
                _gameEnded = true;
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
                return;
            }

            #endregion

            #region checking diag

            if (_results[0] != MarkType.Free && (_results[0] & _results[4] & _results[8]) == _results[0])
            {
                _gameEnded = true;
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
                return;
            }

            if (_results[2] != MarkType.Free && (_results[2] & _results[4] & _results[6]) == _results[2])
            {
                _gameEnded = true;
                Button0_2.Background = Button1_1.Background = Button2_0.Background = Brushes.Green;
                return;
            }

            #endregion

            if (_results.All(r => r != MarkType.Free))
            {
                _gameEnded = true;
                Container.Children.Cast<Button>().ToList().ForEach(button => { button.Background = Brushes.Orange; }
                );
            }
        }
    }
}