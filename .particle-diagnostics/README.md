# Проверка Particle System — 2026-09-30

Проверки выполнены в копии Assets, Packages и ProjectSettings, в Unity 6000.0.56f1,
с Direct3D 11 на NVIDIA GeForce RTX 5060 Ti и флагом
`-diag-job-temp-memory-leak-validation`. Основной открытый Editor не закрывался.

## Результаты

Каждый завершённый прогон длился 60 секунд после подготовки сцены. Скрипт
отключал пользовательские MonoBehaviour из Assembly-CSharp, сохраняя компоненты
URP, принудительно запрашивал игровой цикл через QueuePlayerLoopUpdate и запускал
частицы. Количество кадров в таблице — Time.frameCount, а не измерение количества
отрисованных кадров. Исправленные варианты скрипта успешно скомпилированы Unity.

| Прогон | Игровые кадры | Частицы при завершении | Искомые сообщения |
|---|---:|---|---|
| Исходные Smoke/Fire, Render Graph | 243660 | Fire 14, Smoke 127 | Не обнаружены |
| Smoke/Fire, Compatibility Mode | 247349 | Smoke 126, Fire 14 | Не обнаружены |
| Новый простой Particle System, явная эмиссия 10/с, AlwaysSimulate | 253504 | 50 | Не обнаружены |

Проверялись JobTempAlloc, ThreadsafeLinearAllocator и dummy color attachment.
Логи: scene.log, compatibility.log, default-emission.log в этой директории.
baseline.log — предварительный запуск с некорректным таймером, остановлен вручную.
default.log — предварительный контроль с нулём живых частиц; не засчитывается.

**Ошибка не воспроизведена. Исправление не подтверждено.** Batchmode не повторяет
обычную работу Scene/Game views, Inspector и Gizmos, а наличие графического
устройства и игровой симуляции не доказывает идентичность интерактивного
рендеринга. Проверки не исключают engine bug или ошибку, возникающую с большей
задержкой. Новый простой эффект использует явную эмиссию и AlwaysSimulate,
поэтому не является точной копией объекта, созданного через меню Editor.

В основном проекте не изменены код игры, сцены, материалы, пакеты и рендеринг.
Compatibility Mode менялся только в памяти отдельного тестового процесса,
без сохранения asset; нельзя считать его исправлением по этим результатам.

## Повторный запуск

Копия проекта находится в project/ и исключена из Git. В ней есть
Assets/Editor/ParticleDiagnosticRunner.cs. Шаблон скрипта сохранён отдельно
как ParticleDiagnosticRunner.cs.txt, чтобы его можно было хранить в Git
без добавления Editor-компонента в игру.

Из корня основного проекта выполнить в PowerShell:

```powershell
& 'C:/Program Files/Unity/Hub/Editor/6000.0.56f1/Editor/Unity.exe' -batchmode -projectPath "$PWD/.particle-diagnostics/project" -executeMethod ParticleDiagnosticRunner.Run -diag-job-temp-memory-leak-validation -logFile "$PWD/.particle-diagnostics/repeat.log"
```

Добавить `-particleDiagnosticCompatibility` для Compatibility Mode или
`-particleDiagnosticDefault` для нового простого эффекта. Запускать последовательно,
после завершения предыдущего тестового Editor. Unity может запускаться асинхронно;
проверять маркер PARTICLE_DIAGNOSTIC_COMPLETE в логе, а не только код возврата shell.

## Следующая проверка в интерактивном Editor

1. Запустить тестовую копию с диагностическим флагом, открыть bird.unity.
2. Воспроизвести исходный сценарий с эффектами, переключением Scene/Game,
   выбором Particle System, Gizmos, паузой и рестартами. Сохранить полный лог.
3. Сравнить ту же копию на исправленной версии ветки 6000.0 (6000.0.59f2 или
   более поздний патч), не меняя Graphics API и эффекты между проверками.
4. Проверить Development Build, включив bird.unity в список сцен сборки:
   сохранённые Build Settings основного проекта включают только SampleScene.
5. Если отдельно возникает depth-only warning, менять по одному Gizmos,
   SSAO и Compatibility Mode и записывать результат, сохраняя частицы включёнными.

Версии Unity, установленные на момент теста: 2022.3.62f2, 6000.0.56f1,
6000.2.2f1. Исправленной версии для сравнительного теста нет.

Официальный issue UUM-114725 перечисляет 6000.0.56f1 и ту же последовательность
JobTempAlloc/старые аллокации; он закрыт как дубликат UUM-113839:

- https://issuetracker.unity.com/issues/3882/an-internal-warning-jobtempalloc-has-allocations-that-are-more-than-the-maximum-lifespan-of-4-frames-old-is-being-logged-when-interacting-with-a-particle-system-in-the-editor
- https://issuetracker.unity3d.com/issues/memory-leak-warnings-are-thrown-when-creating-a-particle-system-gameobject-2
- https://unity.com/ja/releases/editor/whats-new/6000.0.59f2

Это остаётся наиболее вероятной причиной; нужна интерактивная репродукция
и сравнение версий либо диагностический стек для окончательного подтверждения.
