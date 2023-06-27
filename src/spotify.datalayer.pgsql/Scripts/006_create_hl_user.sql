﻿CREATE TABLE hl_user (
    id serial PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    phone VARCHAR(20) NOT NULL,
    email VARCHAR(255) NOT NULL,
    role_id INTEGER NOT NULL REFERENCES public.enum_user_role(id),
    salt VARCHAR(255) NOT NULL,
    refresh_token VARCHAR(255),
    refresh_token_expire_date timestamp without time zone,
    password_hash VARCHAR(255) NOT NULL,
    registered_at timestamp without time zone,
    last_login timestamp without time zone,
    status_id INTEGER NOT NULL REFERENCES public.enum_status(id),
    state_id INTEGER REFERENCES public.enum_state(id),
);