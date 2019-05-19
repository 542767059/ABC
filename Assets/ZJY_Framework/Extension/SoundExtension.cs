using ZJY.Framework;

namespace ZJY.Framework
{
    public static class SoundExtension
    {
        private const float FadeVolumeDuration = 1f;
        private static int? s_MusicSerialId = null;

        public static int? PlayMusic(this SoundComponent soundComponent, int musicId, object userData = null)
        {
            soundComponent.StopMusic();

            MusicDBModel musicDBModel = GameEntry.DataTable.GetDataTable<MusicDBModel>();
            MusicEntity musicEntity = musicDBModel.Get(musicId);
            if (musicEntity == null)
            {
                Log.Warning("Can not load music '{0}' from data table.", musicId.ToString());
                return null;
            }
            
            PlaySoundParams playSoundParams = new PlaySoundParams
            {
                Priority = 64,
                Loop = true,
                VolumeInSoundGroup = 1f,
                FadeInSeconds = FadeVolumeDuration,
                SpatialBlend = 0f,
            };

            s_MusicSerialId = soundComponent.PlaySound(AssetUtility.GetMusicAsset(musicEntity.AssetName), "Music", Constant.AssetPriority.MusicAsset, playSoundParams, null, userData);
            return s_MusicSerialId;
        }

        public static void StopMusic(this SoundComponent soundComponent)
        {
            if (!s_MusicSerialId.HasValue)
            {
                return;
            }

            soundComponent.StopSound(s_MusicSerialId.Value, FadeVolumeDuration);
            s_MusicSerialId = null;
        }

        public static void PauseMusic(this SoundComponent soundComponent)
        {
            if (!s_MusicSerialId.HasValue)
            {
                return;
            }
            soundComponent.PauseSound(s_MusicSerialId.Value);
        }

        public static void ResumeMusic(this SoundComponent soundComponent)
        {
            if (!s_MusicSerialId.HasValue)
            {
                return;
            }
            soundComponent.ResumeSound(s_MusicSerialId.Value);
        }

        public static int? PlaySound(this SoundComponent soundComponent, int soundId, Entity bindingEntity = null, object userData = null)
        {
            SoundDBModel soundDBModel = GameEntry.DataTable.GetDataTable<SoundDBModel>();
            SoundEntity soundEntity = soundDBModel.Get(soundId);
            if (soundEntity == null)
            {
                Log.Warning("Can not load sound '{0}' from data table.", soundId.ToString());
                return null;
            }

            PlaySoundParams playSoundParams = new PlaySoundParams
            {
                Priority = soundEntity.Priority,
                Loop = soundEntity.Loop,
                VolumeInSoundGroup = soundEntity.Volume,
                SpatialBlend = soundEntity.SpatialBlend,
            };
            
            return soundComponent.PlaySound(AssetUtility.GetSoundAsset(soundEntity.AssetName), "Sound", Constant.AssetPriority.SoundAsset, playSoundParams, bindingEntity != null ? bindingEntity : null, userData);
        }

        public static int? PlayUISound(this SoundComponent soundComponent, int uiSoundId, object userData = null)
        {
            UISoundDBModel uiSoundDBModel = GameEntry.DataTable.GetDataTable<UISoundDBModel>();
            UISoundEntity uisoundEntity = uiSoundDBModel.Get(uiSoundId);
            if (uisoundEntity == null)
            {
                Log.Warning("Can not load UI sound '{0}' from data table.", uiSoundId.ToString());
                return null;
            }

            PlaySoundParams playSoundParams = new PlaySoundParams
            {
                Priority = uisoundEntity.Priority,
                Loop = false,
                VolumeInSoundGroup = uisoundEntity.Volume,
                SpatialBlend = 0f,
            };

            return soundComponent.PlaySound(AssetUtility.GetUISoundAsset(uisoundEntity.AssetName), "UISound", Constant.AssetPriority.UISoundAsset, playSoundParams, userData);
        }

        public static bool IsMuted(this SoundComponent soundComponent, string soundGroupName)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return true;
            }

            SoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return true;
            }

            return soundGroup.Mute;
        }

        public static void Mute(this SoundComponent soundComponent, string soundGroupName, bool mute)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return;
            }

            SoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return;
            }

            soundGroup.Mute = mute;

            GameEntry.Setting.SetBool(TextUtil.Format(Constant.Setting.SoundGroupMuted, soundGroupName), mute);
            GameEntry.Setting.Save();
        }

        public static float GetVolume(this SoundComponent soundComponent, string soundGroupName)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return 0f;
            }

            SoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return 0f;
            }

            return soundGroup.Volume;
        }

        public static void SetVolume(this SoundComponent soundComponent, string soundGroupName, float volume)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return;
            }

            SoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return;
            }

            soundGroup.Volume = volume;

            GameEntry.Setting.SetFloat(TextUtil.Format(Constant.Setting.SoundGroupVolume, soundGroupName), volume);
            GameEntry.Setting.Save();
        }
    }
}
