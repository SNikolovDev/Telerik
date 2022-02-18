<img src="https://webassets.telerikacademy.com/images/default-source/logos/telerik-academy.svg)" alt="logo" width="300px" style="margin-top: 20px;"/>

# Academy - Unit Testing Workshop

### 1. Description

You are given an already built software system. Your task is to get to know with the way the system works. Check out the tests requirements to know exactly what you must test as not all functionalities must be tested. Before writing any code, familiarize yourself with the project and go through the list of requirements. Follow the `testing guidelines` you've learned. Everything should have a `single responsibility`. Test only the things that the class is concerned about.

### 2. Тest the Academy.Models.Course constructor

- It should correctly initialize the collections.

### 3. Test the Academy.Models.Course Name property

- It should throw `ArgumentException` when passed value is invalid.
- It should correctly assign passed value.

### 4. Test the Academy.Models.Course LecturesPerWeek property

You decide what are the test scenarios.

### 5. Test the Academy.Models.Course StartingDate property

You decide what are the test scenarios.

### 6. Test the Academy.Models.Course EndingDate property

You decide what are the test scenarios.

### 7. Test the Academy.Models.Lecture class

You should decide what needs to be tested and what are the test scenarios.

### 9. Test the Academy.Models.User Username property

- It should throw `ArgumentException` when passed value is invalid.
- It should correctly assign passed value.

### 10. Test the Academy.Commands.Adding.AddStudentToCourseCommand command

- It should throw `ArgumentException` when parameters count is less than expected.
- It should throw `ArgumentException` when seasonId is not a valid integer.
- It should throw `ArgumentException` when courseId is not a valid integer.
- It should throw `InvalidOperationException` when student with specified username does not exist.
- It should throw `ArgumentOutOfRangeException` when seasonId or courseId is invalid.
- It should throw `ArgumentException` when form is not a valid (onsite or online).
- It should return confirmation message when command completes successfully.

### 11. Test the Academy.Commands.Adding.AddStudentToSeasonCommand command

- It should throw `ArgumentException` when parameters count is less than expected.
- It should throw `ArgumentException` when seasonId is not a valid integer.
- It should throw `InvalidOperationException` when student with specified username does not exist.
- It should throw `ArgumentOutOfRangeException` when seasonId is invalid.
- It should throw `ArgumentException` when student is already in the season.
- It should return confirmation message when command completes successfully.

### 12. Test the Academy.Commands.Adding.AddTrainerToSeasonCommand command

You decide what are the test scenarios.

### 13. Analyze the code coverage of the tests that you have created.