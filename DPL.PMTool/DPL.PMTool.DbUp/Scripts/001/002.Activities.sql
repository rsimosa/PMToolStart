create table Activities (
    Id integer primary key not null,
    TaskName text null,
    Estimate numeric,
    Predecessors text,
    Resource text,
    Priority numeric,
    Start datetime null,
    Finish datetime null, 
    CreatedAt datetime not null default current_timestamp,
    UpdatedAt datetime not null default current_timestamp
)