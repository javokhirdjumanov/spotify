CREATE TABLE enum_state (
    id integer PRIMARY KEY,
    state_name VARCHAR(50) NOT NULL
);
INSERT INTO public.enum_state
VALUES
    (1, 'Active'),
    (2, 'InActive');