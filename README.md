# Native Collections Stream
`Stream`, `TextReader` and `TextWriter` implementations backed by Unity Native Collections.


## Feature
- `Stream` implementations:
  + [NativeListStream](Runtime/NativeListStream.cs): stream backed by a `NativeList<byte>`
  + [UnsafeListStream](Runtime/NativeListStream.cs): read-only stream backed by a `UnsafeList<byte>`
  + [FixedList32BytesStream](Runtime/NativeListStream.cs): read-only stream backed by a `FixedList32Bytes<byte>`
  + [FixedList64BytesStream](Runtime/NativeListStream.cs): read-only stream backed by a `FixedList64Bytes<byte>`
  + [FixedList128BytesStream](Runtime/NativeListStream.cs): read-only stream backed by a `FixedList128Bytes<byte>`
  + [FixedList512BytesStream](Runtime/NativeListStream.cs): read-only stream backed by a `FixedList512Bytes<byte>`
  + [FixedList4096BytesStream](Runtime/NativeListStream.cs): read-only stream backed by a `FixedList4096Bytes<byte>`
  + [NativeTextStream](Runtime/NativeTextStream.cs): stream backed by a `NativeText`
  + [UnsafeTextStream](Runtime/NativeTextStream.cs): read-only stream backed by a `UnsafeText`
  + [FixedString32BytesStream](Runtime/NativeTextStream.cs): read-only stream backed by a `FixedString32Bytes`
  + [FixedString64BytesStream](Runtime/NativeTextStream.cs): read-only stream backed by a `FixedString64Bytes`
  + [FixedString128BytesStream](Runtime/NativeTextStream.cs): read-only stream backed by a `FixedString128Bytes`
  + [FixedString512BytesStream](Runtime/NativeTextStream.cs): read-only stream backed by a `FixedString512Bytes`
  + [FixedString4096BytesStream](Runtime/NativeTextStream.cs): read-only stream backed by a `FixedString4096Bytes`
- `TextReader` implementations:
  + [NativeTextReader](Runtime/NativeTextReader.cs): text reader backed by a `NativeText`
  + [UnsafeTextReader](Runtime/NativeTextReader.cs): text reader backed by a `UnsafeText`
  + [FixedString32BytesReader](Runtime/NativeTextReader.cs): text reader backed by a `FixedString32Bytes`
  + [FixedString64BytesReader](Runtime/NativeTextReader.cs): text reader backed by a `FixedString64Bytes`
  + [FixedString128BytesReader](Runtime/NativeTextReader.cs): text reader backed by a `FixedString128Bytes`
  + [FixedString512BytesReader](Runtime/NativeTextReader.cs): text reader backed by a `FixedString512Bytes`
  + [FixedString4096BytesReader](Runtime/NativeTextReader.cs): text reader backed by a `FixedString4096Bytes`
  + [FixedString4096BytesReader](Runtime/NativeTextReader.cs): text reader backed by a `FixedString4096Bytes`
- `TextWriter` implementations:
  + [NativeTextWriter](Runtime/NativeTextWriter.cs): text writer backed by a `NativeText`


## How to install
Either:
- Install using the [Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui-giturl.html) with the following URL:
  ```
  https://github.com/gilzoide/unity-native-collections-stream.git#1.0.0-preview1
  ```
- Clone this repository or download a snapshot of it directly inside your project's `Assets` or `Packages` folder.