using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using TerraUI.Utilities;

namespace TerraUI.Objects {
    public class UINumberBox : UIObject {
        private UITextBox textBox;
        private UIButton upButton;
        private UIButton downButton;
        private int value = 0;
        private int maximum = 100;
        private int minimum = 0;
        private uint stepAmount = 1;

        /// <summary>
        /// Fires when the value of the UINumberBox is changed.
        /// </summary>
        public event ValueChangedEventHandler<int> ValueChanged;
        /// <summary>
        /// The maximum value of the UINumberBox.
        /// </summary>
        public int Maximum {
            get { return maximum; }
            set {
                if(value <= Minimum) {
                    maximum = Minimum + 1;
                }
                else {
                    maximum = value;
                }
            }
        }
        /// <summary>
        /// The minimum value of the UINumberBox.
        /// </summary>
        public int Minimum {
            get { return minimum; }
            set {
                if(value >= Maximum) {
                    minimum = Maximum - 1;
                }
                else {
                    minimum = value;
                }
            }
        }
        /// <summary>
        /// The current value of the UINumberBox.
        /// </summary>
        public int Value {
            get { return value; }
            set {
                if(value > Maximum) {
                    this.value = Maximum;
                }
                else {
                    this.value = value;
                }

                if(textBox != null) {
                    textBox.Text = this.value.ToString();
                }
            }
        }
        /// <summary>
        /// The amount that the value of the UINumberBox changes with each Increase() or Decrease() call.
        /// </summary>
        public uint StepAmount {
            get { return stepAmount; }
            set {
                if(value < 1) {
                    stepAmount = 1;
                }
                else {
                    stepAmount = value;
                }
            }
        }
        /// <summary>
        /// The background color of the UINumberBox.
        /// </summary>
        public Color BackColor { get; set; }
        /// <summary>
        /// The text color of the UINumberBox.
        /// </summary>
        public Color TextColor { get; set; }
        /// <summary>
        /// Font used to draw the text.
        /// </summary>
        public DynamicSpriteFont Font { get; set; }

        /// <summary>
        /// Create a new UINumberBox.
        /// </summary>
        /// <param name="position">position of the object in pixels</param>
        /// <param name="size">size of the object</param>
        /// <param name="value">starting value</param>
        /// <param name="minimum">minimum value</param>
        /// <param name="maximum">maximum value</param>
        /// <param name="stepAmount">amount value changes with each step</param>
        /// <param name="parent">parent UIObject</param>
        public UINumberBox(Vector2 position, Vector2 size, DynamicSpriteFont font, int value = 0, int minimum = 0,
            int maximum = 100, uint stepAmount = 1, UIObject parent = null) : base(position, size, parent, true, true) {
            Font = font;
            Value = value;
            Minimum = minimum;
            Maximum = maximum;
            StepAmount = stepAmount;

            textBox = new UITextBox(Vector2.Zero, new Vector2(size.X - (size.Y / 2) + 2, size.Y), font, value.ToString(),
                parent: this);
            upButton = new UIButton(new Vector2(size.X - (size.Y / 2), 0),
                new Vector2(size.Y / 2, size.Y / 2), font, "", 1, UIUtils.GetTexture("UpArrow"),
                false, this);
            downButton = new UIButton(new Vector2(size.X - (size.Y / 2), size.Y / 2),
                new Vector2(size.Y / 2, size.Y / 2), font, "", 1, UIUtils.GetTexture("DownArrow"),
                false, this);

            upButton.BorderColor = downButton.BorderColor = textBox.BorderColor;

            upButton.Click += UpButton_Click;
            downButton.Click += DownButton_Click;
        }

        private bool UpButton_Click(UIObject sender, MouseButtonEventArgs e) {
            Increase();
            return true;
        }

        private bool DownButton_Click(UIObject sender, MouseButtonEventArgs e) {
            Decrease();
            return true;
        }

        /// <summary>
        /// Increase by the StepAmount.
        /// </summary>
        private void Increase() {
            if(Value < Maximum) {
                Value += (int)StepAmount;

                if(ValueChanged != null) {
                    ValueChanged(this, new ValueChangedEventArgs<int>(Value - (int)StepAmount, Value));
                }
            }
        }

        /// <summary>
        /// Decrease by the StepAmount.
        /// </summary>
        private void Decrease() {
            if(Value > Minimum) {
                Value -= (int)StepAmount;

                if(ValueChanged != null) {
                    ValueChanged(this, new ValueChangedEventArgs<int>(Value + (int)StepAmount, Value));
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            textBox.Draw(spriteBatch);
            upButton.Draw(spriteBatch);
            downButton.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }
    }
}
