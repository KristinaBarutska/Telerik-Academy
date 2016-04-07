/* Task Description */
/*
* Create an object domElement, that has the following properties and methods:
  * use prototypal inheritance, without function constructors
  * method init() that gets the domElement type
    * i.e. `Object.create(domElement).init('div')`
  * property type that is the type of the domElement
    * a valid type is any non-empty string that contains only Latin letters and digits
  * property innerHTML of type string
    * gets the domElement, parsed as valid HTML
      * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
  * property content of type string
    * sets the content of the element
    * works only if there are no children
  * property attributes
    * each attribute has name and value
    * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
  * property children
    * each child is a domElement or a string
  * property parent
    * parent is a domElement
  * method appendChild(domElement / string)
    * appends to the end of children list
  * method addAttribute(name, value)
    * throw Error if type is not valid
  * method removeAttribute(attribute)
    * throw Error if attribute does not exist in the domElement
*/

function solve() {
  'use strict';

  var domElement = (function() {
    function getAttributeKeysSorted(attributes) {
      let sortedKeys = [];

      for (var key in attributes) {
        sortedKeys.push(key);
      }

      sortedKeys.sort();
      return sortedKeys;
    }

    function getAttributeString(sortedAttributeKeys, attributes) {
      let attributeString = '';

      for (let i = 0, len = sortedAttributeKeys.length; i < len; i += 1) {
        attributeString += ` ${sortedAttributeKeys[i]}="${attributes[sortedAttributeKeys[i]]}"`;
      }

      return attributeString;
    }

    var domElement = {
      init: function(type) {
        this.type = type;
        this.content = '';
        this.parent = {};
        this.children = [];
        this.attributes = [];

        return this;
      },
      appendChild: function(child) {
        this.children.push(child);

        if (typeof child === 'object') {
          child.parent = this;
        }

        return this;
      },
      addAttribute: function(name, value) {
        let pattern = /^[A-Z0-9\-]+$/i;

        if (typeof name !== 'string') {
          throw new Error('The type of the attribute name must be of type string!');
        } else if (!pattern.test(name)) {
          throw new Error('Attribute name must contains only latin letters and digits!');
        } else {
          this.attributes[name] = value;
          return this;
        }
      },
      removeAttribute: function(attribute) {
        if (this.attributes[attribute] === undefined) {
          throw new Error('Such attribute does not exist!');
        } else {
          delete this.attributes[attribute];
          return this;
        }
      },
      get innerHTML() {
        let sortedAttributeKeys = getAttributeKeysSorted(this.attributes);
        let attributeString = getAttributeString(sortedAttributeKeys, this.attributes);
        let innerHtmlString = `<${this.type}${attributeString}>`;

        for (let i = 0, len = this.children.length; i < len; i += 1) {
          if (typeof this.children[i] === 'string') {
            innerHtmlString += this.children[i];
          } else {
            innerHtmlString += this.children[i].innerHTML;
          }
        }

        innerHtmlString += `${this.content}</${this.type}>`;
        return innerHtmlString;
      },
      get type() {
        return this._type;
      },
      set type(value) {
        let pattern = /^[A-Z0-9]+$/i;

        if (!pattern.test(value)) {
          throw new Error('Type must contains only latin letters and digits!');
        } else if (typeof value !== 'string') {
          throw new Error('Type must be of type string!');
        } else {
          this._type = value;
        }
      },
      get content() {
        if (this.children.length !== undefined) {
          return '';
        } else {
          return this._content;
        }
      },
      set content(value) {
        this._content = value;
      },
      get attributes() {
        return this._attributes;
      },
      set attributes(value) {
        this._attributes = value;
      },
      get children() {
        return this._children;
      },
      set children(value) {
        this._children = value;
      },
      get parent() {
        return this._parent;
      },
      set parent(value) {
        this._parent = value;
      }
    };
    return domElement;
  }());
  return domElement;
}

module.exports = solve;
