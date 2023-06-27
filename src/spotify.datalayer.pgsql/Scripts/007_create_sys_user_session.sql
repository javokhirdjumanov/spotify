CREATE TABLE sys_user_session (
    id serial PRIMARY KEY,
    token VARCHAR(255) NOT NULL,
    status_id INTEGER NOT NULL REFERENCES public.enum_session_status(id),
    created_at timestamp without time zone NOT NULL,
    user_id int NOT NULL REFERENCES public.hl_user (id)
);