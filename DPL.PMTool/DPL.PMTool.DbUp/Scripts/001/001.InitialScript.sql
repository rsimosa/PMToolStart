create table Projects (
    Id integer primary key not null,
    Name text null,
    Start datetime not null,
    CreatedAt datetime not null default current_timestamp,
    UpdatedAt datetime not null default current_timestamp
)

