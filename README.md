# LINQPadDialogs

[![NuGet Version](https://img.shields.io/nuget/v/LINQPadDialogs)](https://www.nuget.org/packages/LINQPadDialogs/) [![GitHub Sponsors](https://img.shields.io/github/sponsors/rkttu)](https://github.com/sponsors/rkttu/)

A helper library that provides the ability to implement interactive user interfaces using LINQPad's built-in Controls.

LINQPad 8 | LINQPad 5
:--------:| :--------:
![As used in LINQPad 8](docs/images/linqpad8.png) | ![As used in LINQPad 5](docs/images/linqpad5.png)

## Please read before continuing

- This NuGet package is supported by the generosity of community members. A small donation through GitHub Sponsorship will go a long way toward keeping the project running. ([Donate Now](https://github.com/sponsors/rkttu/))
- This library is intended to be used with LINQPad. It is not recommended for use in production development code.
- This package also requires a license of at least the Developer Edition of LINQPad to use it.
- If you write a script using the features provided by this package, it may not be possible to run it with the `lprun` CLI tool.

## Features

I will be gradually developing and supplementing this library.

### Interactivity Features (Button Array)

It provides a simple async/await method to display multiple buttons, and to see what button the user has selected in the console.

If needed, you can customize the `ButtonArray` types that are added to the `LINQPad.Controls` namespace.

Here is an example of the code:

```csharp
using LINQPad.Controls;

switch (await Dialog.YesNo<string>("Are you happy now?", "yes", "no"))
{
	case "yes":
		"Answer: Yes".Dump();
		break;
	case "no":
		"Answer: No".Dump();
		break;
	default:
		"Answer: ?".Dump();
		break;
}
```

### Interactivity Features (Prompt)

Draw a UI that allows you to type whatever you want into the text box. Unlike `Console.In.ReadLine` methods, this feature shows a text box and OK and Cancel buttons on the screen.

Here is an example of the code:

```csharp
using LINQPad.Controls;

var answer = await OkCancelPrompt("What's your name?");

if (answer == default) $"You didn't enter a name.".Dump();
else $"Your name is: {answer}.".Dump();
```

## License

This project is licensed under the [Apache License 2.0](./LICENSE).
