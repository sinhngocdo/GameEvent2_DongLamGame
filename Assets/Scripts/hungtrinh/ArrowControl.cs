using UnityEngine;

namespace hungtrinh
{
    public class ArrowControl : Arrow
    {
        [SerializeField] float          speedRotate;
        Vector3                         direction;
        [SerializeField] AnimationCurve speedScale;
        [SerializeField] float          timeEvaluate;
        [SerializeField] float          speedBase;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            float angleRotate = 0;
            if (Input.GetKey(KeyCode.A))
            {
                angleRotate = (speedRotate * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                angleRotate = -1 * speedRotate * Time.deltaTime;
            }

            direction = Quaternion.Euler(transform.forward) * direction;

            timeEvaluate += Time.deltaTime;
            rigid.velocity = RotateDirection(rigid.velocity, angleRotate, Vector3.forward).normalized *
                             (speedBase * GetSpeedScaleInTime(timeEvaluate));
            Debug.Log(GetSpeedScaleInTime(timeEvaluate));
        }

        public float GetSpeedScaleInTime(float time)
        {
            return speedScale.Evaluate(time);
        }

        public Vector3 RotateDirection(Vector3 direction, float angle, Vector3 axis)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, axis);
            return rotation * direction;
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
        }
    }
}