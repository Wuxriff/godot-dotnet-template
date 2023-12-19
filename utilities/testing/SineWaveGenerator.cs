using Godot;

namespace Utilities;
public partial class SineWaveGenerator : AudioStreamPlayer
{
	private const float PULSE_HZ = 440f; // The frequency of the sound wave.

	// Saved buffer to push to generator repeatedly.
	private Vector2[] _frames;
	private AudioStreamGeneratorPlayback Playback { get => (AudioStreamGeneratorPlayback)GetStreamPlayback(); }

	public override void _Ready()
	{
		if (Stream is AudioStreamGenerator generator)
		{
			Play();
			_frames = CreateFullBuffer();
			FillBuffer();

			Timer timer = new()
			{
				WaitTime = generator.BufferLength * 3,
				Autostart = true
			};
			timer.CheckedConnect(Timer.SignalName.Timeout, Callable.From(FillBuffer));
			AddChild(timer);
		}
	}

	private void FillBuffer() => Playback.PushBuffer(_frames);

	private Vector2[] CreateFullBuffer()
	{
		float _increment = Mathf.Tau * PULSE_HZ / ((AudioStreamGenerator)Stream).MixRate;
		float phase = 0;
		int framesAvailable = Playback.GetFramesAvailable();
		Vector2[] frames = new Vector2[framesAvailable];
		for (int i = 0; i < framesAvailable; i++)
		{
			frames[i] = Vector2.One * Mathf.Sin(phase);
			phase += _increment;
		}

		return frames;
	}
}
