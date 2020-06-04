using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace MineSweeperProjeto.Helpers
{
	public enum SoundEfxEnum
	{
		CLICK,
		FLAG,
		GAMEOVER,
		GAMEWIN,
	}

	public class SoundEffects
	{
		private Dictionary<SoundEfxEnum, MediaElement> effects;

		public SoundEffects()
		{
			effects = new Dictionary<SoundEfxEnum, MediaElement>();
			LoadEfx();
		}

		private async void LoadEfx()
		{
			effects.Add(SoundEfxEnum.CLICK, await LoadSoundFile("click.wav"));
			effects.Add(SoundEfxEnum.FLAG, await LoadSoundFile("flag.wav"));
			effects.Add(SoundEfxEnum.GAMEOVER, await LoadSoundFile("gameOver.wav"));
			effects.Add(SoundEfxEnum.GAMEWIN, await LoadSoundFile("gameWin.wav"));
		}

		private async Task<MediaElement> LoadSoundFile(string v)
		{
			MediaElement snd = new MediaElement();

			snd.AutoPlay = false;
			StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
			StorageFile file = await folder.GetFileAsync(v);
			var stream = await file.OpenAsync(FileAccessMode.Read);
			snd.SetSource(stream, file.ContentType);
			return snd;
		}

		public async Task Play(SoundEfxEnum efx)
		{
			var mediaElement = effects[efx];

			await mediaElement.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
			{
				mediaElement.Stop();
				mediaElement.Play();
			});
		}
	}
}