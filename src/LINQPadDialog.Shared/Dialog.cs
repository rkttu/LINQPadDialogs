#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPad.Controls
{
    /// <summary>
    /// Represents a dialog box with buttons for abort, retry, and ignore options.
    /// </summary>
    public static class Dialog
    {
        /// <summary>
        /// Displays a dialog box with abort, retry, and ignore buttons and returns the selected value.
        /// </summary>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <param name="question">The question to display in the dialog box.</param>
        /// <param name="abortValue">The value to return when the abort button is clicked.</param>
        /// <param name="retryValue">The value to return when the retry button is clicked.</param>
        /// <param name="ignoreValue">The value to return when the ignore button is clicked.</param>
        /// <returns>The selected value.</returns>
        public static async Task<T> AbortRetryIgnore<T>(string question, T abortValue, T retryValue, T ignoreValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new AbortRetryIgnoreButtonArray(_ => tcs.SetResult(abortValue), _ => tcs.SetResult(retryValue), _ => tcs.SetResult(ignoreValue)).Dump(question);
            return await tcs.Task;
        }

        /// <summary>
        /// Displays a dialog box with cancel, try, and continue buttons and returns the selected value.
        /// </summary>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <param name="question">The question to display in the dialog box.</param>
        /// <param name="cancelValue">The value to return when the cancel button is clicked.</param>
        /// <param name="tryValue">The value to return when the try button is clicked.</param>
        /// <param name="continueValue">The value to return when the continue button is clicked.</param>
        /// <returns>The selected value.</returns>
        public static async Task<T> CancelTryContinue<T>(string question, T cancelValue, T tryValue, T continueValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new CancelTryContinueButtonArray(_ => tcs.SetResult(cancelValue), _ => tcs.SetResult(tryValue), _ => tcs.SetResult(continueValue)).Dump(question);
            return await tcs.Task;
        }

        /// <summary>
        /// Displays a dialog box with an OK button and returns the selected value.
        /// </summary>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <param name="message">The message to display in the dialog box.</param>
        /// <param name="okValue">The value to return when the OK button is clicked.</param>
        /// <returns>The selected value.</returns>
        public static async Task<T> OK<T>(string message, T okValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new OKButtonArray(_ => tcs.SetResult(okValue)).Dump(message);
            return await tcs.Task;
        }

        /// <summary>
        /// Displays a dialog box with an OK button.
        /// </summary>
        /// <param name="message">The message to display in the dialog box.</param>
        public static async Task OK(string message)
        {
            var tcs = new TaskCompletionSource<object?>();
            new OKButtonArray(_ => tcs.SetResult(default)).Dump(message);
            await tcs.Task;
        }

        /// <summary>
        /// Displays a dialog box with OK and cancel buttons and returns the selected value.
        /// </summary>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <param name="question">The question to display in the dialog box.</param>
        /// <param name="okValue">The value to return when the OK button is clicked.</param>
        /// <param name="cancelValue">The value to return when the cancel button is clicked.</param>
        /// <returns>The selected value.</returns>
        public static async Task<T> OKCancel<T>(string question, T okValue, T cancelValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new OKCancelButtonArray(_ => tcs.SetResult(okValue), _ => tcs.SetResult(cancelValue)).Dump(question);
            return await tcs.Task;
        }

        /// <summary>
        /// Displays a dialog box with retry and cancel buttons and returns the selected value.
        /// </summary>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <param name="question">The question to display in the dialog box.</param>
        /// <param name="retryValue">The value to return when the retry button is clicked.</param>
        /// <param name="cancelValue">The value to return when the cancel button is clicked.</param>
        /// <returns>The selected value.</returns>
        public static async Task<T> RetryCancel<T>(string question, T retryValue, T cancelValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new OKCancelButtonArray(_ => tcs.SetResult(retryValue), _ => tcs.SetResult(cancelValue)).Dump(question);
            return await tcs.Task;
        }

        /// <summary>
        /// Displays a dialog box with yes and no buttons and returns the selected value.
        /// </summary>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <param name="question">The question to display in the dialog box.</param>
        /// <param name="yesValue">The value to return when the yes button is clicked.</param>
        /// <param name="noValue">The value to return when the no button is clicked.</param>
        /// <returns>The selected value.</returns>
        public static async Task<T> YesNo<T>(string question, T yesValue, T noValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new YesNoButtonArray(_ => tcs.SetResult(yesValue), _ => tcs.SetResult(noValue)).Dump(question);
            return await tcs.Task;
        }

        /// <summary>
        /// Displays a dialog box with yes, no, and cancel buttons and returns the selected value.
        /// </summary>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <param name="question">The question to display in the dialog box.</param>
        /// <param name="yesValue">The value to return when the yes button is clicked.</param>
        /// <param name="noValue">The value to return when the no button is clicked.</param>
        /// <param name="cancelValue">The value to return when the cancel button is clicked.</param>
        /// <returns>The selected value.</returns>
        public static async Task<T> YesNoCancel<T>(string question, T yesValue, T noValue, T cancelValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new YesNoCancelButtonArray(_ => tcs.SetResult(yesValue), _ => tcs.SetResult(noValue), _ => tcs.SetResult(cancelValue)).Dump(question);
            return await tcs.Task;
        }

        /// <summary>
        /// Displays a dialog box with a prompt for user input and returns the entered text.
        /// </summary>
        /// <param name="question">The question to display in the dialog box.</param>
        /// <param name="initialText">The initial text to display in the input field.</param>
        /// <returns>The entered text.</returns>
        public static async Task<string> OKPrompt(string question, string initialText = "")
        {
            var tcs = new TaskCompletionSource<string>(default);
            new OKPrompt(initialText,
                textBox => tcs.SetResult(textBox.Text)).Dump(question);
            return await tcs.Task;
        }

        /// <summary>
        /// Displays a dialog box with a prompt for user input and returns the entered text or null if canceled.
        /// </summary>
        /// <param name="question">The question to display in the dialog box.</param>
        /// <param name="initialText">The initial text to display in the input field.</param>
        /// <returns>The entered text or null if canceled.</returns>
        public static async Task<string?> OKCancelPrompt(string question, string initialText = "")
        {
            var tcs = new TaskCompletionSource<string?>(default);
            new OKCancelPrompt(initialText,
                textBox => tcs.SetResult(textBox.Text),
                textBox => tcs.SetResult(default)).Dump(question);
            return await tcs.Task;
        }

        /// <summary>
        /// Displays a dialog box with a prompt for entering a password and returns the entered password as a string.
        /// </summary>
        /// <param name="question">The question to display in the dialog box.</param>
        /// <param name="initialText">The initial text to display in the password field.</param>
        /// <returns>The entered password as a string.</returns>
        public static async Task<string?> PasswordPrompt(string question, string initialText = "")
        {
            var tcs = new TaskCompletionSource<object?>();
            var prompt = new PasswordPrompt(initialText,
                pwdBox => tcs.SetResult(default)).Dump(question);
            await tcs.Task.ConfigureAwait(false);
            return prompt.GetRawPassword();
        }

        /// <summary>
        /// Displays a dialog box with a prompt for entering a password and returns the entered password as a byte array encoded with the specified encoding.
        /// </summary>
        /// <param name="question">The question to display in the dialog box.</param>
        /// <param name="targetEncoding">The encoding to use for encoding the password as a byte array.</param>
        /// <param name="initialText">The initial text to display in the password field.</param>
        /// <returns>The entered password as a byte array encoded with the specified encoding.</returns>
        public static async Task<byte[]?> PasswordPromptAsBytes(string question, Encoding targetEncoding, string initialText = "")
        {
            var tcs = new TaskCompletionSource<object?>();
            var prompt = new PasswordPrompt(initialText,
                pwdBox => tcs.SetResult(default)).Dump(question);
            await tcs.Task.ConfigureAwait(false);
            return prompt.GetEncodedPassword(targetEncoding);
        }

        /// <summary>
        /// Displays a dialog box with a prompt for selecting one answer from multiple options and returns the selected answer.
        /// </summary>
        /// <param name="question">The question to display in the dialog box.</param>
        /// <param name="optionCallback">An optional callback to customize the appearance of the radio buttons.</param>
        /// <param name="defaultValue">The default value to select.</param>
        /// <param name="options">The available options to choose from.</param>
        /// <returns>The selected answer.</returns>
        public static async Task<string?> SelectOneAnswerPrompt(string question, Action<RadioButton>? optionCallback = default, string? defaultValue = default, params string[] options)
        {
            var tcs = new TaskCompletionSource<object?>();
            var prompt = new SelectOneAnswerPrompt(
                optionCallback,
                _ => tcs.SetResult(default),
                defaultValue,
                options).Dump(question);
            await tcs.Task.ConfigureAwait(false);
            return prompt.GetSelectedRadioButton()?.Text;
        }

        /// <summary>
        /// Displays a dialog box with a prompt for selecting multiple answers from multiple options and returns the selected answers.
        /// </summary>
        /// <param name="question">The question to display in the dialog box.</param>
        /// <param name="optionCallback">An optional callback to customize the appearance of the checkboxes.</param>
        /// <param name="options">The available options to choose from.</param>
        /// <returns>The selected answers.</returns>
        public static async Task<IEnumerable<string>> SelectMultipleAnswersPrompt(string question, Action<CheckBox>? optionCallback = default, params string[] options)
        {
            var tcs = new TaskCompletionSource<object?>();
            var prompt = new SelectMultipleAnswersPrompt(
                optionCallback,
                _ => tcs.SetResult(default),
                options).Dump(question);
            await tcs.Task.ConfigureAwait(false);
            return prompt.GetSelectedCheckBoxes().Select(x => x.Text);
        }
    }
}
