Garden Of Dreams

2D игра с системой строительства, реализованной на New Input System.

Управление
- **ЛКМ** - Выбор/Взаимодействие
- **ПКМ** - Отмена 
- **ESC** - Выход из режима удаления
- **Мышь** - Наведение и перемещение

Технологии
- Unity 2022.3.62.f2
- New Input System
- C#

Архитектура
- Input System с Event-based подходом
- Separation of Concerns через UnityEvents
- Modular input handling

Структура проекта
Assets/
    Scripts/
    Core/
    BuildingInputHandler.cs // Обработчик ввода
    BuildingInputs.inputactions // Конфигурация Input System

Установка и запуск
1. Клонируйте репозиторий
2. Откройте проект в Unity 2022.3.62.f2+
3. Убедитесь, что установлен Input System Package