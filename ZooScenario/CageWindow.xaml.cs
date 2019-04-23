using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CagedItems;
using Utilities;
using Zoos;

namespace ZooScenario
{
    /// <summary>
    /// Interaction logic for CageWindow.xaml.
    /// </summary>
    public partial class CageWindow : Window
    {
        /// <summary>
        /// A cage in the zoo.
        /// </summary>
        private Cage cage;

        /// <summary>
        /// Timer for redraw events.
        /// </summary>
        private Timer redrawTimer;

        /// <summary>
        /// Initializes a new instance of the CageWindow class.
        /// </summary>
        /// <param name="cage"> The cage to use. </param>
        public CageWindow(Cage cage)
        {
            this.InitializeComponent();
            this.cage = cage;
            this.redrawTimer = new Timer(100);
            this.redrawTimer.Elapsed += this.RedrawHandler;
            this.redrawTimer.Start();
        }

        /// <summary>
        /// Draws an item in the cage.
        /// </summary>
        /// <param name="item"> The item to draw.</param>
        private void DrawItem(ICageable item)
        {
            string resourceKey = item.ResourceKey;

            Viewbox viewBox = this.GetViewBox(800, 400, item.XPosition, item.YPosition, item.ResourceKey, item.DisplaySize);

            viewBox.HorizontalAlignment = HorizontalAlignment.Left;
            viewBox.VerticalAlignment = VerticalAlignment.Top;

            // If the animal is moving to the left
            if (item.XDirection == HorizontalDirection.Left)
            {
                // Set the origin point of the transformation to the middle of the viewBox.
                viewBox.RenderTransformOrigin = new Point(0.5, 0.5);

                // Initialize a ScaleTransform instance.
                ScaleTransform flipTransform = new ScaleTransform();

                // Flip the viewBox horizontally so the animal faces to the left
                flipTransform.ScaleX = -1;

                // Apply the ScaleTransform to the viewBox
                viewBox.RenderTransform = flipTransform;
            }

            this.cageGrid.Children.Add(viewBox);
        }

        /// <summary>
        /// Gets the view box.
        /// </summary>
        /// <param name="maxXPosition"> The max x position. </param>
        /// <param name="maxYPosition"> The max y position. </param>
        /// <param name="xPosition"> The x position. </param>
        /// <param name="yPosition"> The y position. </param>
        /// <param name="resourceKey"> The resource key. </param>
        /// <param name="displayScale"> The display size. </param>
        /// <returns> Returns the finished view box. </returns>
        private Viewbox GetViewBox(double maxXPosition, double maxYPosition, int xPosition, int yPosition, string resourceKey, double displayScale)
        {
            Canvas canvas = Application.Current.Resources[resourceKey] as Canvas;

            // Finished viewBox.
            Viewbox finishedViewBox = new Viewbox();

            // Gets image ratio.
            double imageRatio = canvas.Width / canvas.Height;

            // Sets width to a percent of the window size based on it's scale.
            double itemWidth = this.cageGrid.ActualWidth * 0.2 * displayScale;

            // Sets the height to the ratio of the width.
            double itemHeight = itemWidth / imageRatio;

            // Sets the width of the viewBox to the size of the canvas.
            finishedViewBox.Width = itemWidth;
            finishedViewBox.Height = itemHeight;

            // Sets the animals location on the screen.
            double xPercent = (this.cageGrid.ActualWidth - itemWidth) / maxXPosition;
            double yPercent = (this.cageGrid.ActualHeight - itemHeight) / maxYPosition;

            int posX = Convert.ToInt32(xPosition * xPercent);
            int posY = Convert.ToInt32(yPosition * yPercent);

            finishedViewBox.Margin = new Thickness(posX, posY, 0, 0);

            // Adds the canvas to the view box.
            finishedViewBox.Child = canvas;

            // Returns the finished viewBox.
            return finishedViewBox;
        }

        /// <summary>
        /// Loads the window and draws all items.
        /// </summary>
        /// <param name="sender"> The object that initiated the event. </param>
        /// <param name="e"> The event arguments for the event. </param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DrawAllItems();
        }

        /// <summary>
        /// Handles redrawing the events.
        /// </summary>
        /// <param name="sender"> The object that initiated the event. </param>
        /// <param name="e"> The event arguments for the event. </param>
        private void RedrawHandler(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(delegate()
            {
                this.DrawAllItems();
            }));
        }

        /// <summary>
        /// Draws all items in the cage window.
        /// </summary>
        private void DrawAllItems()
        {
            this.cageGrid.Children.Clear();

            foreach (ICageable a in this.cage.CagedItems)
            {
                this.DrawItem(a);
            }                       
        }
    }
}
