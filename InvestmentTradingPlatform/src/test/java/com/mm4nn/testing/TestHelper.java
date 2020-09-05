package com.mm4nn.testing;

import nl.jqno.equalsverifier.EqualsVerifier;
import nl.jqno.equalsverifier.Warning;
import nl.jqno.equalsverifier.api.SingleTypeEqualsVerifierApi;

import com.google.common.base.Preconditions;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.lang.reflect.Constructor;
import java.lang.reflect.Method;
import java.lang.reflect.Modifier;

public final class TestHelper {

    private static final Logger LOG =
            LoggerFactory.getLogger(TestHelper.class);

    /**
     * Helper class. Prevent creation
     */
    private TestHelper() {

    }

    private static <T> SingleTypeEqualsVerifierApi<T> createEqualsVerifier(Class<T> pojoType) {

        SingleTypeEqualsVerifierApi<T> equalsVerifier = EqualsVerifier.forClass(pojoType);

        // Suppress the warnings we don't care about
        equalsVerifier.suppress(Warning.INHERITED_DIRECTLY_FROM_OBJECT);
        equalsVerifier.suppress(Warning.STRICT_INHERITANCE);
        equalsVerifier.suppress(Warning.NONFINAL_FIELDS);

        return equalsVerifier;

    }

    /**
     * Validates the equals/hashcode methods are properly implemented.
     *
     * @param pojoType Class instance of POJO to test
     * @param redefinesBase Type redefines a subclasses equals
     * @param left Actual value used to test equals if provided
     * @param right Actual value used to test equals if provided
     * @param <T> Type of POJO
     * @return boolean indicating if the input has proper equals and hashCode
     */
    private static <T> boolean validateEqualsAndHashCode(
            Class<T> pojoType, boolean redefinesBase, T left, T right) {

        SingleTypeEqualsVerifierApi<T> equalsVerifier = createEqualsVerifier(pojoType);

        if (redefinesBase) {
            equalsVerifier.withRedefinedSuperclass();
        }

        if (left != null && right != null) {
            equalsVerifier.withPrefabValues(pojoType, left, right);
        }

        // verify equality semantics
        equalsVerifier.verify();

        return true;

    }

    /**
     * Validates the equals/hashcode methods are properly implemented.
     *
     * @param pojoType Class instance of POJO to test
     * @param redefinesBase Type redefines a subclasses equals
     * @param <T> Type of POJO
     * @return boolean indicating if the input has proper equals and hashCode
     */
    private static <T> boolean validateEqualsAndHashCode(
            Class<T> pojoType, boolean redefinesBase) {
        return validateEqualsAndHashCode(pojoType, redefinesBase, null, null);
    }

    /**
     * Check if class is a good POJO:
     *   - Does it have a default constructable
     *   - Does it override toString
     *   - Does it have a proper equals and hashCode override
     *
     *   Note: Use of the Lombok @Data annotation takes care of most
     *   of these.
     *
     * @param pojoType Class instance of POJO to test
     * @param redefinesBase Type redefines a subclasses equals
     * @param <T> Type of POJO
     * @return boolean indicating if the input is a good POJO
     */
    public static <T> boolean isGoodPojo(Class<T> pojoType, boolean redefinesBase) {

        try {

            // Check for default constructable
            T instance = pojoType.getDeclaredConstructor()
                    .newInstance();

            // Check if toString is overridden
            var test = pojoType.getMethod("toString").getDeclaringClass();
            Preconditions.checkArgument(test != Object.class,
                    "Does not override toString");

            // Print for visual inspection
            LOG.info("Instances of POJO {} will show up as {} in logs",
                    pojoType.getSimpleName(), instance);

            return validateEqualsAndHashCode(pojoType, redefinesBase);

        }
        catch (Exception err) {
            LOG.warn("Not a good POJO", err);
            return false;
        }

    }

    /**
     * Check if class is a good POJO:
     *   - Does it have a default constructable
     *   - Does it override toString
     *   - Does it have a proper equals and hashCode override
     *
     *   Note: Use of the Lombok @Data annotation takes care of most
     *   of these.
     *
     * @param pojoType Class instance of POJO to test
     * @param <T> Type of POJO
     * @return boolean indicating if the input is a good POJO
     */
    public static <T> boolean isGoodPojo(Class<T> pojoType) {
        return isGoodPojo(pojoType, false);
    }

    public static <T> boolean isGoodHelperClass(Class<T> helperType) {

        // Must be final
        Preconditions.checkState(Modifier.isFinal(helperType.getModifiers()),
                "helper class must be marked final");

        // Single private constructor
        Constructor<?>[] constructors = helperType.getDeclaredConstructors();
        Preconditions.checkState(1 == constructors.length,
                "helper class must have a single constructor");
        Preconditions.checkState(Modifier.isPrivate(constructors[0].getModifiers()),
                "helper classes constructor must be private");

        // All methods must be static
        for (Method method : helperType.getMethods()) {
            if (method.getDeclaringClass().equals(helperType)) {
                Preconditions.checkState(Modifier.isStatic(method.getModifiers()),
                        String.format("helper method %s must be static", method.getName()));
            }
        }

        return true;

    }

}
