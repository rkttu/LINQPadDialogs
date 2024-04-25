#nullable enable

using LINQPad.Controls.Resources;
using System;

namespace LINQPad.Controls
{
    /// <summary>
    /// Represents an abstract class for a button array.
    /// </summary>
    public abstract class ButtonArray : Div
    {
        /// <summary>
        /// Initializes a new instance of the ButtonArray class with the specified buttons.
        /// </summary>
        /// <param name="buttons">The buttons to include in the button array.</param>
        public ButtonArray(params Button[] buttons) :
            base(new StackPanel(true, buttons))
        { }
    }

    /// <summary>
    /// Represents a button array with "Abort", "Retry", and "Ignore" buttons.
    /// </summary>
    public class AbortRetryIgnoreButtonArray : ButtonArray
    {
        /// <summary>
        /// Initializes a new instance of the AbortRetryIgnoreButtonArray class with the specified buttons.
        /// </summary>
        /// <param name="abortCallback">The callback action for the "Abort" button.</param>
        /// <param name="retryCallback">The callback action for the "Retry" button.</param>
        /// <param name="ignoreCallback">The callback action for the "Ignore" button.</param>
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


    /// <summary>
    /// Represents a button array with "Cancel", "Try", and "Continue" buttons.
    /// </summary>
    public class CancelTryContinueButtonArray : ButtonArray
    {
        /// <summary>
        /// Initializes a new instance of the CancelTryContinueButtonArray class with the specified buttons.
        /// </summary>
        /// <param name="cancelCallback">The callback action for the "Cancel" button.</param>
        /// <param name="tryCallback">The callback action for the "Try" button.</param>
        /// <param name="continueCallback">The callback action for the "Continue" button.</param>
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

    /// <summary>
    /// Represents a button array with an "OK" button.
    /// </summary>
    public class OKButtonArray : ButtonArray
    {
        /// <summary>
        /// Initializes a new instance of the OKButtonArray class with the specified buttons.
        /// </summary>
        /// <param name="okCallback">The callback action for the "OK" button.</param>
        public OKButtonArray(
            Action<Button>? okCallback = default) : base(new Button[] {
                new Button(UIStringResources.Button_OK, okCallback),
            })
        { }
    }

    /// <summary>
    /// Represents a button array with "OK" and "Cancel" buttons.
    /// </summary>
    public class OKCancelButtonArray : ButtonArray
    {
        /// <summary>
        /// Initializes a new instance of the OKCancelButtonArray class with the specified buttons.
        /// </summary>
        /// <param name="okCallback">The callback action for the "OK" button.</param>
        /// <param name="cancelCallback">The callback action for the "Cancel" button.</param>
        public OKCancelButtonArray(
            Action<Button>? okCallback = default,
            Action<Button>? cancelCallback = default) : base(new Button[] {
                new Button(UIStringResources.Button_OK, okCallback),
                new Button(UIStringResources.Button_Cancel, cancelCallback),
            })
        { }
    }

    /// <summary>
    /// Represents a button array with "Retry" and "Cancel" buttons.
    /// </summary>
    public class RetryCancelButtonArray : ButtonArray
    {
        /// <summary>
        /// Initializes a new instance of the RetryCancelButtonArray class with the specified buttons.
        /// </summary>
        /// <param name="retryCallback">The callback action for the "Retry" button.</param>
        /// <param name="cancelCallback">The callback action for the "Cancel" button.</param>
        public RetryCancelButtonArray(
            Action<Button>? retryCallback = default,
            Action<Button>? cancelCallback = default) : base(new Button[] {
                new Button(UIStringResources.Button_Retry, retryCallback),
                new Button(UIStringResources.Button_Cancel, cancelCallback),
            })
        { }
    }

    /// <summary>
    /// Represents a button array with "Yes" and "No" buttons.
    /// </summary>
    public class YesNoButtonArray : ButtonArray
    {
        /// <summary>
        /// Initializes a new instance of the YesNoButtonArray class with the specified buttons.
        /// </summary>
        /// <param name="yesCallback">The callback action for the "Yes" button.</param>
        /// <param name="noCallback">The callback action for the "No" button.</param>
        public YesNoButtonArray(
            Action<Button>? yesCallback = default,
            Action<Button>? noCallback = default) : base(new Button[] {
                new Button(UIStringResources.Button_Yes, yesCallback),
                new Button(UIStringResources.Button_No, noCallback),
            })
        { }
    }

    /// <summary>
    /// Represents a button array with "Yes", "No", and "Cancel" buttons.
    /// </summary>
    public class YesNoCancelButtonArray : ButtonArray
    {
        /// <summary>
        /// Initializes a new instance of the YesNoCancelButtonArray class with the specified buttons.
        /// </summary>
        /// <param name="yesCallback">The callback action for the "Yes" button.</param>
        /// <param name="noCallback">The callback action for the "No" button.</param>
        /// <param name="cancelCallback">The callback action for the "Cancel" button.</param>
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
