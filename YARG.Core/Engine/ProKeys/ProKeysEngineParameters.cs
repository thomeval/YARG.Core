using System.IO;
using YARG.Core.Extensions;
using YARG.Core.Game;

namespace YARG.Core.Engine.ProKeys
{
    public class ProKeysEngineParameters : BaseEngineParameters
    {
        public readonly double ChordStaggerWindow;

        public readonly double FatFingerWindow;

        public readonly bool IncrementComboPerChord;

        public ProKeysEngineParameters(HitWindowSettings hitWindow, int maxMultiplier, double spWhammyBuffer,
            double sustainDropLeniency, float[] starMultiplierThresholds, double chordStaggerWindow, double fatFingerWindow, int streakPerMultiplier, bool incrementComboPerChord)
            : base(hitWindow, maxMultiplier, spWhammyBuffer, sustainDropLeniency, starMultiplierThresholds, streakPerMultiplier)
        {
            ChordStaggerWindow = chordStaggerWindow;
            FatFingerWindow = fatFingerWindow;
            IncrementComboPerChord = incrementComboPerChord;
        }

        public ProKeysEngineParameters(UnmanagedMemoryStream stream, int version)
            : base(stream, version)
        {
            ChordStaggerWindow = stream.Read<double>(Endianness.Little);
            FatFingerWindow = stream.Read<double>(Endianness.Little);

            // TODO: This is an override for testing purposes. Remove when done.
            StreakPerMultiplier = EnginePreset.KEYS_STREAK_PER_MULTIPLIER;
            IncrementComboPerChord = EnginePreset.KEYS_COMBO_INC_PER_CHORD;
        }

        public override void Serialize(BinaryWriter writer)
        {
            base.Serialize(writer);

            writer.Write(ChordStaggerWindow);
            writer.Write(FatFingerWindow);
        }

        public override string ToString()
        {
            return
                $"{base.ToString()}\n" +
                $"Chord stagger window: {ChordStaggerWindow}\n" +
                $"Fat finger window: {FatFingerWindow}";
        }
    }
}