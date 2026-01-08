# CoreLabs.NET.Logger — Detailed Documentation

This document provides verbose, per-file documentation and guidance for consumers and maintainers.

## Purpose
A compact, dependency-free logging library with:
- A small surface area (LogLevel, ILogger).
- A console sink with colored output.
- A static façade for convenience in apps/tests.
- Extensibility via custom sinks implementing ILogger.

---

## Files and responsibilities

### SystemBackends/InterfaceAPI.cs
- Defines LogLevel enum and ILogger interface.
- LogLevel: ordered severity levels (Trace → Critical).
- ILogger.Log(level, message, exception?): core contract sinks implement.
- Guidance: sinks should avoid throwing and document thread-safety. Library authors should prefer DI for long-lived services, using ILogger in constructors.

### SystemBackends/LoggerAPI.cs
- Implements ConsoleLogger : ILogger.
- Writes a compact line: [Level] yyyy-MM-dd HH:mm:ss: Message
- Colors text using Colors.ConsoleColorManager before writing.
- Prints exception.ToString() on following lines if provided.
- Intended for development and small tools; not a durable production sink.

### SystemBackends/ConsoleColorManager.cs
- Centralizes console color choices.
- Call Reset() after use to prevent bleeding colors into other output.

### Logger.cs
- Static façade delegating to CoreLogger.
- Exposes AddSink, Write, and convenience methods (Info, Warn, Error, etc.).
- Recommends registering sinks at startup and preferring DI for libraries.

### Program.cs
- Removed from library; examples moved to docs.
- Create separate sample console app if an executable demo is required.

---

## Usage examples

- Add the library as a project/package reference.

- Simple usage (any app or test):
````csharp
Log.Info("Application started");
Log.Success("Operation completed");
Log.Warn("Configuration missing value");
Log.Error("Failed to load component", ex);