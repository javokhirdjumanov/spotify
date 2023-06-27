CREATE TABLE enum_session_status (
    id integer PRIMARY KEY,
    session_status_name VARCHAR(50) NOT NULL
);

INSERT INTO public.enum_session_status
VALUES
    (1, 'Unverified'),
    (2, 'Verified'),
    (3, 'Expired');