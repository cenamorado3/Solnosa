(function(root, factory)
{
    if(typeof definine === 'function' && definine.amd)
    {
        definine(factory);
    }

    else if (typeof exports === 'object')
    {
        module.exports = factory();
    }

    else
    {
        root.Transform = factory;
    }
}

(this || window, function(){
    'use strict';

    var Transform = {},
    _transformClass = 'transform',

    DEFAULT_EVENTS = {
        transform : ['click'],
        revert : ['click']
    };



        var GetElementList = function (elements) {
            if (typeof elements == 'string') {
                return Array.prototype.slice.call(document.querySelectorAll(elements));
            }

            else if (typeof elements === 'undefined' || elements instanceof Array) {
                return elements;
            }

            else {
                return [elements];
            }
        };

        var GetEventsList = function (events) {
            if (typeof events === 'string') {
                return events.toLowerCase().split(' ');
            }

            else {
                return events;
            }
        };

        var SetListeners = function (elements, events, remove) {
            method = (remove ? 'remove' : 'add') + 'EventListener',
                elementList = GetElementList(elements),
                currentElement = elementList.length,
                eventsList = {};

            for (var prop in DEFAULT_EVENTS) {
                eventLists[prop] = (events && events[prop]) ? GetEventList(events[prop]) : DEFAULT_EVENTS[prop];
            }

            while (currentElement--) {
                for (var occasion in eventsList) {
                    var currentEvent = eventsList[occasion].length;
                    while (currentEvent--) {
                        elementList[currentElement][method](eventLists[occasion][currentEvent], HandleEvent);
                    }
                }
            }

        };

        var HandleEvent = function (event) {
            Transform.ToggleAnimation(event.currentTarget);
        };

        Transform.Add = function (elements, events) {
            SetListeners(elements, events, true);
            return Transform;
        };

        Transform.Remove = function (elements, events) {
            SetListeners(elements, events, true);
            return Transform;
        };

        Transform.Transform = function (elements) {
            GetElementList(elements).forEach(function (element) {
                element.classList.add(_transformClass);
            });
            return Transform;
        };

        Transform.Revert = function (elements) {
            GetElementList(elements).forEach(function (element) {
                element.classList.remove(_transformClass);
            });
            return Transform;
        };

        Transform.HasClass = function(element, className) 
        {
            if(element.classList.contains(className))
            {
                return true;
            }

            if(!element.classList.contains(className))
            {
                return false;
            }
        };

        Transform.ToggleAnimation = function (elements, className) {
            GetElementList(elements).forEach(function (element) {
                if (HasClass(element, _transformClass)) {
                    Transform.AddAnimation(element);
                }

                else if (!HasClass(element, _transformClass)) {
                    Transform.RemoveAnimation(element);
                }

                return Transform;
            });
        };

        Transform.Toggle = function (elements) {
            getElementList(elements).forEach(function (element) {
                tcon[element.classList.contains(_transformClass) ? 'revert' : 'transform'](element);
            });
            return tcon;
        };

    return Transform;
}));