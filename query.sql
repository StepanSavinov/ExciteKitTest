WITH ranked_events AS (
        SELECT
            Id,
            UserId,
            CaptureDt,
            Url,
            EventContext,
            EventName,
            Item,
            ROW_NUMBER() OVER (PARTITION BY UserId ORDER BY CaptureDt) AS step_number,
            COUNT(*) OVER (PARTITION BY UserId) AS total_steps
        FROM
            events
    )
    SELECT
        re.UserId,
        re.Url AS step_url,
        re.EventName AS step_event,
        re.step_number,
        re.total_steps
    FROM
        ranked_events re
    ORDER BY
        re.UserId, re.step_number;