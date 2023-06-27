CREATE TABLE enum_otp_code_status (
    id integer PRIMARY KEY,
    code_status VARCHAR(50) NOT NULL
);

INSERT INTO public.enum_otp_code_status
VALUES
    (1, 'Unverified'),
    (2, 'Verified'),
    (3, 'Expired'),
    (4, 'Blocked');