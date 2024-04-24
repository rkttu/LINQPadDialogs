#nullable enable

using LINQPad.Controls.Resources;
using System;

namespace LINQPad.Controls
{
    public abstract class ButtonArray : Div
    {
        private static readonly string ButtonSeparator = " ";

        public ButtonArray(params Button[] buttons) :
            base(buttons.JoinControls(new Label(ButtonSeparator)))
        { }
    }

    public class AbortRetryIgnoreButtonArray : ButtonArray
    {
        public AbortRetryIgnoreButtonArray(
            Action<Button>? abortCallback = default,
            Action<Button>? retryCallback = default,
            Action<Button>? ignoreCallback = default) : base(new Button[] {
            new Button(UIStringResources.Button_Abort, abortCallback),
            new Button(UIStringResources.Button_Retry, retryCallback),
            new Button(UIStringResources.Button_Ignore, ignoreCallback),
            })
        { }
    }

    public class CancelTryContinueButtonArray : ButtonArray
    {
        public CancelTryContinueButtonArray(
            Action<Button>? cancelCallback = default,
            Action<Button>? tryCallback = default,
            Action<Button>? continueCallback = default) : base(new Button[] {
            new Button(UIStringResources.Button_Cancel, cancelCallback),
            new Button(UIStringResources.Button_Try, tryCallback),
            new Button(UIStringResources.Button_Continue, continueCallback),
            })
        { }
    }

    public class OKButtonArray : ButtonArray
    {
        public OKButtonArray(
            Action<Button>? okCallback = default) : base(new Button[] {
            new Button(UIStringResources.Button_OK, okCallback),
            })
        { }
    }

    public class OKCancelButtonArray : ButtonArray
    {
        public OKCancelButtonArray(
            Action<Button>? okCallback = default,
            Action<Button>? cancelCallback = default) : base(new Button[] {
            new Button(UIStringResources.Button_OK, okCallback),
            new Button(UIStringResources.Button_Cancel, cancelCallback),
            })
        { }
    }

    public class RetryCancelButtonArray : ButtonArray
    {
        public RetryCancelButtonArray(
            Action<Button>? retryCallback = default,
            Action<Button>? cancelCallback = default) : base(new Button[] {
            new Button(UIStringResources.Button_Retry, retryCallback),
            new Button(UIStringResources.Button_Cancel, cancelCallback),
            })
        { }
    }

    public class YesNoButtonArray : ButtonArray
    {
        public YesNoButtonArray(
            Action<Button>? yesCallback = default,
            Action<Button>? noCallback = default) : base(new Button[] {
            new Button(UIStringResources.Button_Yes, yesCallback),
            new Button(UIStringResources.Button_No, noCallback),
            })
        { }
    }

    public class YesNoCancelButtonArray : ButtonArray
    {
        public YesNoCancelButtonArray(
            Action<Button>? yesCallback = default,
            Action<Button>? noCallback = default,
            Action<Button>? cancelCallback = default) : base(new Button[] {
            new Button(UIStringResources.Button_Yes, yesCallback),
            new Button(UIStringResources.Button_No, noCallback),
            new Button(UIStringResources.Button_Cancel, cancelCallback),
            })
        { }
    }
}
