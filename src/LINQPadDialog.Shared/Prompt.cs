#nullable enable

using LINQPad.Controls.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQPad.Controls
{
    /// <summary>
    /// Represents a base class for prompt dialogs.
    /// </summary>
    public abstract class PromptBase : Div
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PromptBase"/> class with the specified children.
        /// </summary>
        /// <param name="children">The children controls of the prompt.</param>
        public PromptBase(IEnumerable<Control> children) : base(children) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PromptBase"/> class.
        /// </summary>
        public PromptBase() : base() { }

        /// <summary>
        /// Overrides the <see cref="Div.OnRendering"/> method to set focus on the first child control.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> object that contains the event data.</param>
        protected override void OnRendering(EventArgs e)
        {
            this.Children.FirstOrDefault()?.Focus();
            base.OnRendering(e);
        }
    }

    /// <summary>
    /// Represents a prompt dialog with a password input field and an OK button.
    /// </summary>
    public class PasswordPrompt : PromptBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordPrompt"/> class.
        /// </summary>
        /// <param name="initialText">The initial text for the password input field.</param>
        /// <param name="okCallback">The callback action to be invoked when the OK button is clicked.</param>
        public PasswordPrompt(string initialText = "", Action<PasswordBox>? okCallback = default)
        {
            _passwordBox = new PasswordBox(initialText: initialText);
            _okButton = new Button(UIStringResources.Button_OK, (button) => okCallback?.Invoke(_passwordBox));
            this.Children.Add(_passwordBox);
            this.Children.Add(new StackPanel(true, _okButton));
        }

        private readonly PasswordBox _passwordBox = default!;
        private readonly Button _okButton = default!;

        /// <summary>
        /// Gets the raw password entered in the password input field.
        /// </summary>
        /// <returns>The raw password.</returns>
        public string GetRawPassword() => _passwordBox.Text;

        /// <summary>
        /// Gets the encoded password entered in the password input field using the specified encoding.
        /// </summary>
        /// <param name="targetEncoding">The encoding to use for encoding the password.</param>
        /// <returns>The encoded password as a byte array.</returns>
        public byte[] GetEncodedPassword(Encoding targetEncoding) => targetEncoding.GetBytes(_passwordBox.Text);
    }

    /// <summary>
    /// Represents a prompt dialog with an OK button.
    /// </summary>
    public class OKPrompt : PromptBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OKPrompt"/> class.
        /// </summary>
        /// <param name="initialText">The initial text for the prompt.</param>
        /// <param name="okCallback">The callback action to be invoked when the OK button is clicked.</param>
        public OKPrompt(string initialText = "", Action<TextBox>? okCallback = default)
        {
            _textBox = new TextBox(initialText: initialText);
            _okButton = new Button(UIStringResources.Button_OK, (button) => okCallback?.Invoke(_textBox));
            this.Children.Add(_textBox);
            this.Children.Add(new StackPanel(true, _okButton));
        }

        private readonly TextBox _textBox = default!;
        private readonly Button _okButton = default!;
    }

    /// <summary>
    /// Represents a prompt dialog with an OK and Cancel button.
    /// </summary>
    public class OKCancelPrompt : PromptBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OKCancelPrompt"/> class.
        /// </summary>
        /// <param name="initialText">The initial text for the prompt.</param>
        /// <param name="okCallback">The callback action to be invoked when the OK button is clicked.</param>
        /// <param name="cancelCallback">The callback action to be invoked when the Cancel button is clicked.</param>
        public OKCancelPrompt(string initialText = "", Action<TextBox>? okCallback = default, Action<TextBox>? cancelCallback = default)
        {
            _textBox = new TextBox(initialText: initialText);
            _okButton = new Button(UIStringResources.Button_OK, (button) => okCallback?.Invoke(_textBox));
            _cancelButton = new Button(UIStringResources.Button_Cancel, (button) => cancelCallback?.Invoke(_textBox));
            this.Children.Add(_textBox);
            this.Children.Add(new StackPanel(true, _okButton, _cancelButton));
        }

        private readonly TextBox _textBox = default!;
        private readonly Button _okButton = default!;
        private readonly Button _cancelButton = default!;
    }

    /// <summary>
    /// Represents a prompt dialog with a set of radio buttons for selecting one answer.
    /// </summary>
    public class SelectOneAnswerPrompt : PromptBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectOneAnswerPrompt"/> class.
        /// </summary>
        /// <param name="optionCallback">The callback action to be invoked when an option is selected.</param>
        /// <param name="submitButtonCallback">The callback action to be invoked when the Submit button is clicked.</param>
        /// <param name="defaultValue">The default value for the radio button.</param>
        /// <param name="options">The available options for the radio buttons.</param>
        public SelectOneAnswerPrompt(Action<RadioButton>? optionCallback = default, Action<Button>? submitButtonCallback = default, string? defaultValue = default, params string[] options)
        {
            var groupName = Guid.NewGuid().ToString("n");
            _radioButtons = options.Select(x => new RadioButton(groupName, x, string.Equals(x, defaultValue), optionCallback)).ToArray();
            _submitButton = new Button(UIStringResources.Button_Select, submitButtonCallback);
            _stackPanel = new StackPanel(false, _radioButtons);
            _stackPanel.Children.Add(_submitButton);
            this.Children.Add(_stackPanel);
        }

        private readonly RadioButton[] _radioButtons;
        private readonly Button _submitButton;
        private readonly StackPanel _stackPanel;

        /// <summary>
        /// Gets the selected radio button.
        /// </summary>
        /// <returns>The selected radio button.</returns>
        public RadioButton? GetSelectedRadioButton() => _radioButtons.FirstOrDefault(x => x.Checked);
    }

    /// <summary>
    /// Represents a prompt dialog with a set of checkboxes for selecting multiple answers.
    /// </summary>
    public class SelectMultipleAnswersPrompt : PromptBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectMultipleAnswersPrompt"/> class.
        /// </summary>
        /// <param name="optionCallback">The callback action to be invoked when an option is selected.</param>
        /// <param name="submitButtonCallback">The callback action to be invoked when the Submit button is clicked.</param>
        /// <param name="options">The available options for the checkboxes.</param>
        public SelectMultipleAnswersPrompt(Action<CheckBox>? optionCallback = default, Action<Button>? submitButtonCallback = default, params string[] options)
        {
            _checkBoxes = options.Select(x => new CheckBox(x, false, optionCallback)).ToArray();
            _submitButton = new Button(UIStringResources.Button_Select, submitButtonCallback);
            _stackPanel = new StackPanel(false, _checkBoxes);
            _stackPanel.Children.Add(_submitButton);
            this.Children.Add(_stackPanel);
        }

        private readonly CheckBox[] _checkBoxes;
        private readonly Button _submitButton;
        private readonly StackPanel _stackPanel;

        /// <summary>
        /// Gets the selected checkboxes.
        /// </summary>
        /// <returns>The selected checkboxes.</returns>
        public IEnumerable<CheckBox> GetSelectedCheckBoxes() => _checkBoxes.Where(x => x.Checked);
    }
}
