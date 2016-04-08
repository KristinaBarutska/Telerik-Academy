/* Task Description */
/*
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
  'use strict';

  function validateTitle(title) {
    if (title.length === 0) {
      throw new Error('Title cannot be empty string!');
    } else if (title[0] === ' ' || title[title.length - 1] === ' ') {
      throw new Error('Title cannot start or end with space!');
    } else if (title.length === 0) {
      throw new Error('Title must has atleast one character!');
    } else {
      for (let i = 0, len = title.length; i < len - 1; i += 1) {
        if (title[i] === ' ' && title[i + 1] === ' ') {
          throw new Error('Title cannot contains consecutive spaces!');
        }
      }
    }
  }

  function validateStudentName(name) {
    if (name[0] !== name[0].toUpperCase()) {
      throw new Error('Name must starts with an upper case letter!');
    } else {
      for (let i = 1, len = name.length; i < len; i += 1) {
        if (name[i] !== name[i].toLowerCase()) {
          throw new Error('All letters except the first one must be lower cased!');
        }
      }
    }
  }

  function validateId(studentID, homeworkID, studentsCount, presentationsCount) {
    if (!isValidID(studentID)) {
      throw new Error('Invalid student ID!');
    }

    if (!isValidID(homeworkID)) {
      throw new Error('Invalid homework ID!');
    }

    if (studentID > studentsCount) {
      throw new Error('Incorrect student ID!');
    }

    if (homeworkID > presentationsCount) {
      throw new Error('Incorrect homework ID!');
    }
  }

  var Course = {
    init: function(title, presentations) {
      this.title = title;
      this.presentations = presentations;
      this.students = [];

      return this;
    },
    get title() {
      return this._title;
    },
    set title(value) {
      validateTitle(value);
      this._title = value;
    },
    get presentations() {
      return this._presentations;
    },
    set presentations(value) {
      if (value.length === 0) {
        throw new Error('No presentations were provided!');
      } else {
        this._presentations = value;
      }
    },
    addStudent: function(name) {
      let names = name.split(' ');
      let firstname = names[0];
      let lastname = names[1];

      if (names.length !== 2) {
        throw new Error('First name and last name must be provided!');
      } else {
        validateStudentName(firstname);
        validateStudentName(lastname);
      }

      let id = this.students.length;

      let student = {
        firstname: firstname,
        lastname: lastname,
        id: id
      };

      this.students.push(student);
      return id;
    },
    getAllStudents: function() {
      return this.students;
    },
    submitHomework: function(studentID, homeworkID) {
      validateId(studentID, homeworkID, this.students.length, this.presentations.length);

      validateId(studentID, this.students);
      validateId(homeworkID, this.presentations);
    },
    pushExamResults: function(results) {
      if (!Array.isArray(results)) {
        throw new Error('Array of results should be provided!');
      } else {
        for (let i = 0, len = results.length; i < len; i += 1) {
          let studentId = results[i].StudentID;
          let score = results[i].score;

          validateId(studentId, this.students);

          if (isNaN(score)) {
            throw new Error('Score must be convertible to number!');
          } else {
            this.students[studentId - 1].hasExam = true;
            this.students[studentId - 1].score = score;
          }
        }
      }
    },
    getTopStudents: function() {}
  };

  return Course;
}


module.exports = solve;
