#### What database models do you know?
* Hierarchical Model: The hierarchical model organizes data in tree structure. There is hierarchy of parent and child data segments. This structure implies that a record can have repeating information, generally in the child data segments. These data types are equivalent of tables in the relational model, and with the individual records beeing the equivalent of rows.

* Network Model: In this model some data were more naturally modeled with more than one parent per child. The network model permitted the modeling of many-to-many relationships in data. The basic data modeling construct in the network model is the set construct. A set consists of an owner record type, a set name, and a member record type.

* Relational Mode: A relational database allows the definition of data structures, storage and retrieval operations and intengrity constraints. In such a database the data and relations between them are organised in tables. A table is collection of records and each record in the table contains the same fields.
Properties of relational tables:
    1. Values are atomic
    2. Each row is unique
    3. Column values are of the same kind 
    4. The sequence of columns is insignificant
    5. The sequence of rows is insignificant
    6. Each column has unique name 

* Object/Relational Model: ORDBMSs add new object storage capabilities to the relational systems at the core of modern information systems. The new facilities integrate management of traditional fielded data, complex objects such as time-series and geospatial data and diverse binary media such as audio, video, images and applets.

* Object-Oriented Model: Object DBMSs add database functionality to object programming languages. They bring much more than persistant storage of programming language objects. Object DBMSs extend the semantics of C++, Smalltalk and Java object programming languages. A major benefit of this approach is the unification of the application and database development into seamless data model and language environment.

#### Which are the main functions performed by a Relational Database Management System (RDBMS)?
##### There are several functions that a DBMS performs to ensure data integrity and consistency:
* Data Dictionary Management
* Data Storage Management
* Data Transformation and Presentation
* Security Management
* Multiuser Access Control
* Backup and Recovery Management
* Data Integrity Management
* Database Access Languages and Application Programming Interfaces
* Database Communication Interfaces
* Transaction Management

#### Define what is "table" in database terms.
* A table is a collection of related data held in structured format within a database. It consists of fields(columns) and rows. In relational databases and flat file databases, a table is a set of data elements (values) using a model of vertical columns (identifiable by name) and horizontal rows, the cell being the unit where a row and column intersect.

#### Explain the difference between a primary and a foreign key.
* Primary key is a column or combination of columns that contain values that uniquely identify each row in the table.
* Foreign key is a column or combination of columns that is used to establish and enforce a link between the data in two tables to control the data that can be stored in the foreign key table.

#### Explain the different kinds of relationships between tables in relational databases.
* One-To-Many relationships: In this type of relationship, a row in table A can have many matching rows in the table B, but the row in table B can have only one matching row in table A.
* Many-To-Many relationships: In this type of relationship, a row in table A can have many matching rows in the table B and vice versa.
* One-To-One relationships: In this type of relationship, a row in table A can have no more than one matching row in table B, and vice versa. A one-to-one relationship is created if both of the related columns are primary keys or have unique constraints.

#### When is a certain database schema normalized?
* Organised database is such a database that the results of using the database are always unambiguous and as intended.

#### What are database integrity constraints and when are they used?
* Integrity constraints provide a way of ensuring that changes made to the database by authorized users do not result in a loss of data consistency. An integrity constraint can be any arbitrary predicate applied to the database. They may be costly to evaluate, so we will only consider integrity constraints that can be tested with minimal overhead.

#### Point out the pros and cons of using indexes in a database.
* Indexes are very helpful when we have large amount of data and we want to be able to search fast by given property. In this case we create an index on this property. This has it’s cost – every index creates a B-tree which makes creating deleting and altering data connected to this property (including itself) slower – as the B-tree has to rearrange from time to time as new data is inserted.

#### What's the main purpose of the SQL language?
* SQL is a special-purpose programming language designed for managing data held in a relational database management system (RDBMS), or for stream processing in a relational data stream management system (RDSMS).

#### What are transactions used for?
* Transactions are used to execute several actions as one. Transactions provide an "all-or-nothing" proposition, stating that each work-unit performed in a database must either complete in its entirety or have no effect whatsoever. Further, the system must isolate each transaction from other transactions, results must conform to existing constraints in the database, and transactions that complete successfully must get written to durable storage.

#### What is a NoSQL database?
* This database provides a mechanism for storage and retrieval of data which is modeled in means other than the tabular relations used in relational databases. NoSQL databases are increasingly used in big data and real-time web applications.











