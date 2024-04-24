<Query Kind="Statements">
  <Reference>.\LINQPadDialog.LP8\bin\Debug\net6.0\LINQPadDialog.dll</Reference>
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

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
