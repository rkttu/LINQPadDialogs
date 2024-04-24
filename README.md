# LINQPadDialogs

[![NuGet Version](https://img.shields.io/nuget/v/LINQPadDialogs)](https://www.nuget.org/packages/LINQPadDialogs/)

A helper library that provides the ability to implement interactive user interfaces using LINQPad's built-in Controls.

## Please read before continuing

- This library is intended to be used with LINQPad. It is not recommended for use in production development code.
- This package also requires a license of at least the Developer Edition of LINQPad to use it.
- If you write a script using the features provided by this package, it may not be possible to run it with the `lprun` CLI tool.

## Features

I will be gradually developing and supplementing this library.

### Interactivity Features

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

## License

This project is licensed under the Apache License 2.0.
