using Godot;
using Utilities;

namespace UI;
public partial class VolumeSetting : HBoxContainer
{
	[Export(PropertyHint.Enum, "MasterVolume,MusicVolume,SfxVolume")]
	string volumeName;

	private Slider volumeSlider;
	private Label volumeValue;


	public override void _Ready()
	{
		GetNode<Label>("%Volume Label").Text = VolumeToLabel();
		volumeSlider = GetNode<Slider>("%Volume Slider");
		volumeValue = GetNode<Label>("%Volume Value");

		volumeSlider.CheckedConnect(Slider.SignalName.DragEnded, Callable.From<bool>(_on_drag_ended));
		volumeSlider.CheckedConnect(Slider.SignalName.ValueChanged, Callable.From<double>(_on_value_changed));

		float volume = (float)AudioManager.Instance.GetIndexed(volumeName) * 100f;
		volumeSlider.SetValueNoSignal(volume);
		volumeValue.Text = volume.ToString();
	}

	public void _on_drag_ended(bool changed)
	{
		if (!changed)
			return;

		Logger.WriteInfo($"MasterVolumeSetting::_on_drag_ended({changed}) - User changed volume to {volumeSlider.Value}");
		AudioManager.Instance.SetDeferred(volumeName, volumeSlider.Value / 100f);
	}

	public void _on_value_changed(double value)
	{
		volumeValue.Text = value.ToString();
	}

	private string VolumeToLabel()
	{
		return volumeName switch
		{
			"MasterVolume" => "Master Volume",
			"MusicVolume" => "Music Volume",
			"SfxVolume" => "SFX Volume",
			_ => throw new System.ComponentModel.InvalidEnumArgumentException($"VolumeSetting::volumeToLabel - {volumeName} is not one of the possible values")
		};
	}
}
