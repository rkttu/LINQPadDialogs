#nullable enable

using LINQPad.Controls;
using LINQPad.Controls.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQPad.Controls
{
    public class OKPrompt : Div
    {
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

    public class OKCancelPrompt : Div
    {
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

    public class SelectOneAnswerPrompt : Div
    {
        public SelectOneAnswerPrompt(Action<RadioButton>? optionCallback = default, Action<Button>? submitButtonCallback = default, string? defaultValue = default, params string[] options)
        {
            var groupName = Guid.NewGuid().ToString("n");
            _radioButtons = options.Select(x => new RadioButton(groupName, x, string.Equals(x, defaultValue), optionCallback)).ToArray();
            _submitButton = new Button("Select", submitButtonCallback);
            _stackPanel = new StackPanel(false, _radioButtons);
            _stackPanel.Children.Add(_submitButton);
            this.Children.Add(_stackPanel);
        }

        private readonly RadioButton[] _radioButtons;
        private readonly Button _submitButton;
        private readonly StackPanel _stackPanel;

        public RadioButton? GetSelectedRadioButton() => _radioButtons.FirstOrDefault(x => x.Checked);
    }

    public class SelectMultipleAnswersPrompt : Div
    {
        public SelectMultipleAnswersPrompt(Action<CheckBox>? optionCallback = default, Action<Button>? submitButtonCallback = default, params string[] options)
        {
            _checkBoxes = options.Select(x => new CheckBox(x, false, optionCallback)).ToArray();
            _submitButton = new Button("Select", submitButtonCallback);
            _stackPanel = new StackPanel(false, _checkBoxes);
            _stackPanel.Children.Add(_submitButton);
            this.Children.Add(_stackPanel);
        }

        private readonly CheckBox[] _checkBoxes;
        private readonly Button _submitButton;
        private readonly StackPanel _stackPanel;

        public IEnumerable<CheckBox> GetSelectedCheckBoxes() => _checkBoxes.Where(x => x.Checked);
    }
}
