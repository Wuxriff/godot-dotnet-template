using Godot;

namespace Utilities;
public static class Miscellaneous
{
	public static bool IsValid<T>(this T node) where T : GodotObject
	{
		return node is not null
				&& GodotObject.IsInstanceValid(node)
				&& !node.IsQueuedForDeletion();
	}

	public static Error CheckedConnect<T>(this T node, in StringName signal, in Callable callable, uint flags = 0) where T : Node
	{
		if (!node.IsConnected(signal, callable)
			|| ((GodotObject.ConnectFlags)flags).HasFlag(GodotObject.ConnectFlags.ReferenceCounted))
			return node.Connect(signal, callable, flags);
		return Error.InvalidParameter;
	}
}