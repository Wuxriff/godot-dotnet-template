using System;
using System.Reflection.Metadata.Ecma335;
using Godot;

namespace Utilities;
public partial class VideoManager : Node
{
	private const string VIDEO_SECTION = "Video";

	private Vector2I _resolution;
	public Vector2I Resolution
	{
		get => _resolution;
		set
		{
			_resolution = value;
			GetWindow().Size = value;
			Configuration.Instance.ChangeSetting(VIDEO_SECTION, PropertyName.Resolution, value);
		}
	}

	private int _refreshRate;
	public int RefreshRate
	{
		get => _refreshRate;
		set
		{
			_refreshRate = value;
			Engine.MaxFps = value;
			Configuration.Instance.ChangeSetting(VIDEO_SECTION, PropertyName.RefreshRate, value);
		}
	}

	private DisplayServer.WindowMode _windowMode;
	public DisplayServer.WindowMode WindowMode
	{
		get => _windowMode;
		set
		{
			_windowMode = value;
			DisplayServer.WindowSetMode(value);
			Configuration.Instance.ChangeSetting(VIDEO_SECTION, PropertyName.WindowMode, Enum.GetName(value));
		}
	}

	private DisplayServer.VSyncMode _vsyncMode;
	public DisplayServer.VSyncMode VSyncMode
	{
		get => _vsyncMode;
		set
		{
			_vsyncMode = value;
			DisplayServer.WindowSetVsyncMode(value);
			Configuration.Instance.ChangeSetting(VIDEO_SECTION, PropertyName.VSyncMode, Enum.GetName(value));
		}
	}


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (Configuration.Instance.HasSetting(VIDEO_SECTION, PropertyName.Resolution))
		{
			Logger.Instance.WriteInfo("VideoManager::_Ready() - Initializing Settings from Configuration");
			Resolution = Configuration.Instance.GetSetting<Vector2I>(VIDEO_SECTION, PropertyName.Resolution);
			RefreshRate = Configuration.Instance.GetSetting<int>(VIDEO_SECTION, PropertyName.RefreshRate);
			WindowMode = Enum.Parse<DisplayServer.WindowMode>(Configuration.Instance.GetSetting<string>(VIDEO_SECTION, PropertyName.WindowMode));
			VSyncMode = Enum.Parse<DisplayServer.VSyncMode>(Configuration.Instance.GetSetting<string>(VIDEO_SECTION, PropertyName.VSyncMode));
		}
		else
		{
			Logger.Instance.WriteInfo("VideoManager::_Ready() - Default Initialization from Configuration");
			Resolution = DisplayServer.ScreenGetSize();
			RefreshRate = 0;
			WindowMode = DisplayServer.WindowMode.Windowed;
			VSyncMode = DisplayServer.VSyncMode.Disabled;
		}
	}
}