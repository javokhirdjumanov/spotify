CREATE TABLE enum_user_role (
    id integer PRIMARY KEY,
    role_name VARCHAR(50) NOT NULL
);
INSERT INTO public.enum_user_role
VALUES
    (1, 'SuperAdmin'),
    (2, 'Admin'),
    (3, 'User');