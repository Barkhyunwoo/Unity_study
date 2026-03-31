#include <stdlib.h>	
#include <GL/glut.h>	


static GLfloat spin = 0.0;

int spinToggle = 0;

void display(void) {
	int r, g, b;
	r = rand() % 256;
	g = rand() % 256;
	b = rand() % 256;

	glClear(GL_COLOR_BUFFER_BIT);

	glPushMatrix();
	glRotatef(spin, 0.0, 0.0, 1.0);
	glColor3f((GLfloat)r / 255, (GLfloat)g / 255, (GLfloat)b / 255);
	glRectf(-25.0, -25.0, 25.0, 25.0);
	glPopMatrix();

	glutSwapBuffers();
}

void spinDisplay(void) {
	spin += 0.5;
	if (spin > 360.0) spin = spin - 360.0;
	glutPostRedisplay();
}

void backspinDisplay(void) {
	spin -= 0.5;
	if (spin < 0.0) spin = spin + 360.0;
	glutPostRedisplay();
}

void init(void) {
	glClearColor(0.0, 0.0, 0.0, 0.0);
	glShadeModel(GL_FLAT);
}

void reshape(int w, int h) {
	glViewport(0, 0, (GLsizei)w, (GLsizei)h);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glOrtho(-50.0, 50.0, -50.0, 50.0, -1.0, 1.0);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
}

void mouse(int button, int state, int x, int y) {
	switch (button)
	{
	case GLUT_LEFT_BUTTON:
		if (state == GLUT_DOWN) glutIdleFunc(spinDisplay);
		break;

	case GLUT_RIGHT_BUTTON:
		if (state == GLUT_DOWN) {
			if (spinToggle == 0) {
				glutIdleFunc(spinDisplay);
				spinToggle = 1;
			}
			else if (spinToggle == 1) {
				glutIdleFunc(backspinDisplay);
				spinToggle = 0;
			}
				
				
		
		}
		break;

	default:
		break;
	}
}

int main(int argc, char** argv) {
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
	glutInitWindowSize(600, 400);
	glutInitWindowPosition(100, 100);
	glutCreateWindow("별 만들기");
	init();
	glutDisplayFunc(display);
	glutReshapeFunc(reshape);
	glutMouseFunc(mouse);

	glutMainLoop();
	return 0;
}