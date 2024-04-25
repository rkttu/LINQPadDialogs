#nullable enable

using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace LINQPad.Controls
{
    public static class Dialog
    {
        public static async Task<T> AbortRetryIgnore<T>(string question, T abortValue, T retryValue, T ignoreValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new AbortRetryIgnoreButtonArray(_ => tcs.SetResult(abortValue), _ => tcs.SetResult(retryValue), _ => tcs.SetResult(ignoreValue)).Dump(question);
            return await tcs.Task;
        }

        public static async Task<T> CancelTryContinue<T>(string question, T cancelValue, T tryValue, T continueValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new CancelTryContinueButtonArray(_ => tcs.SetResult(cancelValue), _ => tcs.SetResult(tryValue), _ => tcs.SetResult(continueValue)).Dump(question);
            return await tcs.Task;
        }

        public static async Task<T> OK<T>(string message, T okValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new OKButtonArray(_ => tcs.SetResult(okValue)).Dump(message);
            return await tcs.Task;
        }

        public static async Task OK(string message)
        {
            var tcs = new TaskCompletionSource<object?>();
            new OKButtonArray(_ => tcs.SetResult(default)).Dump(message);
            await tcs.Task;
        }

        public static async Task<T> OKCancel<T>(string question, T okValue, T cancelValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new OKCancelButtonArray(_ => tcs.SetResult(okValue), _ => tcs.SetResult(cancelValue)).Dump(question);
            return await tcs.Task;
        }

        public static async Task<T> RetryCancel<T>(string question, T retryValue, T cancelValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new OKCancelButtonArray(_ => tcs.SetResult(retryValue), _ => tcs.SetResult(cancelValue)).Dump(question);
            return await tcs.Task;
        }

        public static async Task<T> YesNo<T>(string question, T yesValue, T noValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new YesNoButtonArray(_ => tcs.SetResult(yesValue), _ => tcs.SetResult(noValue)).Dump(question);
            return await tcs.Task;
        }

        public static async Task<T> YesNoCancel<T>(string question, T yesValue, T noValue, T cancelValue)
        {
            var tcs = new TaskCompletionSource<T>(default);
            new YesNoCancelButtonArray(_ => tcs.SetResult(yesValue), _ => tcs.SetResult(noValue), _ => tcs.SetResult(cancelValue)).Dump(question);
            return await tcs.Task;
        }

        public static async Task<string> OKPrompt(string question, string initialText = "")
        {
            var tcs = new TaskCompletionSource<string>(default);
            new OKPrompt(initialText,
                textBox => tcs.SetResult(textBox.Text)).Dump(question);
            return await tcs.Task;
        }

        public static async Task<string?> OKCancelPrompt(string question, string initialText = "")
        {
            var tcs = new TaskCompletionSource<string?>(default);
            new OKCancelPrompt(initialText,
                textBox => tcs.SetResult(textBox.Text),
                textBox => tcs.SetResult(default)).Dump(question);
            return await tcs.Task;
        }

        public static async Task<string?> SelectOneAnswerPrompt(string question, Action<RadioButton>? optionCallback = default, string? defaultValue = default, params string[] options)
        {
            var tcs = new TaskCompletionSource();
            var prompt = new SelectOneAnswerPrompt(
                optionCallback,
                _ => tcs.SetResult(),
                defaultValue,
                options).Dump(question);
            await tcs.Task.ConfigureAwait(false);
            return prompt.GetSelectedRadioButton()?.Text;
        }

        public static async Task<IEnumerable<string>> SelectMultipleAnswersPrompt(string question, Action<CheckBox>? optionCallback = default, params string[] options)
        {
            var tcs = new TaskCompletionSource();
            var prompt = new SelectMultipleAnswersPrompt(
                optionCallback,
                _ => tcs.SetResult(),
                options).Dump(question);
            await tcs.Task.ConfigureAwait(false);
            return prompt.GetSelectedCheckBoxes().Select(x => x.Text);
        }
    }
}
