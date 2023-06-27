CREATE TABLE enum_status (
    id integer PRIMARY KEY,
    status_name VARCHAR(50) NOT NULL
);
INSERT INTO public.enum_status
VALUES
    (1, 'New'),
    (2, 'Delete');