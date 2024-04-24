#nullable enable

using LINQPad.Controls;
using LINQPad.Controls.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQPad.Controls
{
    public class OkPrompt : Div
    {
        public OkPrompt(string initialText = "", Action<TextBox>? okCallback = default)
        {
            _textBox = new TextBox(initialText: initialText);
            _okButton = new Button(UIStringResources.Button_OK, (button) => okCallback?.Invoke(_textBox));
            this.Children.Add(_textBox);
            this.Children.Add(new StackPanel(true, _okButton));
        }

        private readonly TextBox _textBox = default!;
        private readonly Button _okButton = default!;
    }

    public class OkCancelPrompt : Div
    {
        public OkCancelPrompt(string initialText = "", Action<TextBox>? okCallback = default, Action<TextBox>? cancelCallback = default)
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
}
